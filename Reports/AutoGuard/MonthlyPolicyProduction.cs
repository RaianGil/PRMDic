using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace EPolicy2.Reports.AutoGuard
{
	public class MonthlyPolicyProduction : DataDynamics.ActiveReports.ActiveReport3
	{
		string _FromDate;
		string _ToDate;
		string _ReportType;
		bool   _Summary = false;
        string _mHeadCompany = "";

        public MonthlyPolicyProduction(string FromDate, string ToDate, string ReportType, bool Summary, string mHeadCompany)
		{
			_FromDate = FromDate;
			_ToDate = ToDate;
			_ReportType = ReportType;
			_Summary  =  Summary;
            _mHeadCompany = mHeadCompany;

			InitializeComponent();
		}

		private void MonthlyPolicyProduction_ReportStart(object sender, System.EventArgs eArgs)
		{
            Label236.Text = _mHeadCompany;
			if (_Summary)
			{
				this.Detail.Visible = false;
			}

			this.lblDate.Text = "Date:"+DateTime.Now.ToShortDateString();
			this.lblTime.Text = "Time:"+DateTime.Now.ToShortTimeString();

//			if (!_FromDate.Trim().Equals("")||(!_FromDate.Trim().Equals("")))
//			{
				this.lblCriterias.Text =  _FromDate.Trim();
//			}
		}

		private void ReportHeader_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		#region ActiveReports Designer generated code
		private ReportHeader ReportHeader = null;
		private Label Label80 = null;
		private Label lblDate = null;
		private Label lblTime = null;
		private Label lblCriterias = null;
		private Label Label236 = null;
		private Label Label237 = null;
		private TextBox TextBox17 = null;
		private PageHeader PageHeader = null;
		private Shape Shape3 = null;
		private Label Label200 = null;
		private Label Label201 = null;
		private Label Label202 = null;
		private Label Label203 = null;
		private Label Label204 = null;
		private Label Label205 = null;
		private Label Label206 = null;
		private Label Label207 = null;
		private Label Label208 = null;
		private Label Label209 = null;
		private Label Label210 = null;
		private Label Label211 = null;
		private Label Label212 = null;
		private Label Label213 = null;
		private Label Label214 = null;
		private Label Label215 = null;
		private Label Label216 = null;
		private Label Label217 = null;
		private Label Label218 = null;
		private Label Label219 = null;
		private Label Label220 = null;
		private Label Label221 = null;
		private Label Label222 = null;
		private Label Label223 = null;
		private Label Label224 = null;
		private Label Label225 = null;
		private Label Label226 = null;
		private Label Label227 = null;
		private Label Label228 = null;
		private Label Label229 = null;
		private Label Label230 = null;
		private Label Label231 = null;
		private Label Label232 = null;
		private Line Line103 = null;
		private Line Line104 = null;
		private Line Line105 = null;
		private Line Line106 = null;
		private Line Line107 = null;
		private Line Line108 = null;
		private Line Line109 = null;
		private Line Line110 = null;
		private Line Line111 = null;
		private Line Line112 = null;
		private Line Line113 = null;
		private Line Line114 = null;
		private Line Line115 = null;
		private Line Line116 = null;
		private Line Line117 = null;
		private Line Line118 = null;
		private Line Line119 = null;
		private Line Line120 = null;
		private Line Line121 = null;
		private Line Line122 = null;
		private Line Line123 = null;
		private Line Line124 = null;
		private Line Line125 = null;
		private Line Line126 = null;
		private Line Line127 = null;
		private Line Line128 = null;
		private Line Line129 = null;
		private Line Line130 = null;
		private Line Line131 = null;
		private Line Line132 = null;
		private Line Line133 = null;
		private Line Line134 = null;
		private Line Line135 = null;
		private Label Label233 = null;
		private Label Label235 = null;
		private Detail Detail = null;
		private Line Line35 = null;
		private Line Line70 = null;
		private Line Line71 = null;
		private Line Line72 = null;
		private Line Line73 = null;
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
		private Line Line86 = null;
		private Line Line87 = null;
		private Line Line88 = null;
		private Line Line89 = null;
		private Line Line90 = null;
		private Line Line91 = null;
		private Line Line92 = null;
		private Line Line93 = null;
		private Line Line94 = null;
		private Line Line95 = null;
		private Line Line96 = null;
		private Line Line97 = null;
		private Line Line98 = null;
		private Line Line99 = null;
		private Line Line100 = null;
		private Line Line101 = null;
		private Line Line102 = null;
		private TextBox TextBox32 = null;
		private TextBox TextBox33 = null;
		private TextBox TextBox34 = null;
		private TextBox TextBox35 = null;
		private TextBox TextBox36 = null;
		private TextBox TextBox37 = null;
		private TextBox TextBox38 = null;
		private TextBox TextBox39 = null;
		private TextBox TextBox40 = null;
		private TextBox TextBox41 = null;
		private TextBox TextBox42 = null;
		private TextBox TextBox43 = null;
		private TextBox TextBox44 = null;
		private TextBox TextBox45 = null;
		private TextBox TextBox46 = null;
		private TextBox TextBox47 = null;
		private TextBox TextBox48 = null;
		private TextBox TextBox49 = null;
		private TextBox TextBox50 = null;
		private TextBox TextBox51 = null;
		private TextBox TextBox52 = null;
		private TextBox TextBox53 = null;
		private TextBox TextBox54 = null;
		private TextBox TextBox55 = null;
		private TextBox TextBox56 = null;
		private TextBox TextBox57 = null;
		private TextBox TextBox58 = null;
		private TextBox TextBox59 = null;
		private TextBox TextBox60 = null;
		private TextBox TextBox61 = null;
		private TextBox TextBox62 = null;
		private TextBox TextBox63 = null;
		private TextBox TextBox64 = null;
		private Line Line136 = null;
		private Label Label133 = null;
		private TextBox TextBox98 = null;
		private Line Line173 = null;
		private PageFooter PageFooter = null;
		private ReportFooter ReportFooter = null;
		private Line Line137 = null;
		private Line Line138 = null;
		private Line Line139 = null;
		private Line Line140 = null;
		private Line Line141 = null;
		private Line Line142 = null;
		private Line Line143 = null;
		private Line Line144 = null;
		private Line Line145 = null;
		private Line Line146 = null;
		private Line Line147 = null;
		private Line Line148 = null;
		private Line Line149 = null;
		private Line Line150 = null;
		private Line Line151 = null;
		private Line Line152 = null;
		private Line Line153 = null;
		private Line Line154 = null;
		private Line Line155 = null;
		private Line Line156 = null;
		private Line Line157 = null;
		private Line Line158 = null;
		private Line Line159 = null;
		private Line Line160 = null;
		private Line Line161 = null;
		private Line Line162 = null;
		private Line Line163 = null;
		private Line Line164 = null;
		private Line Line165 = null;
		private Line Line166 = null;
		private Line Line167 = null;
		private Line Line168 = null;
		private Line Line169 = null;
		private Line Line170 = null;
		private Line Line171 = null;
		private TextBox TextBox65 = null;
		private TextBox TextBox66 = null;
		private TextBox TextBox67 = null;
		private TextBox TextBox68 = null;
		private TextBox TextBox69 = null;
		private TextBox TextBox70 = null;
		private TextBox TextBox71 = null;
		private TextBox TextBox72 = null;
		private TextBox TextBox73 = null;
		private TextBox TextBox74 = null;
		private TextBox TextBox75 = null;
		private TextBox TextBox76 = null;
		private TextBox TextBox77 = null;
		private TextBox TextBox78 = null;
		private TextBox TextBox79 = null;
		private TextBox TextBox80 = null;
		private TextBox TextBox81 = null;
		private TextBox TextBox82 = null;
		private TextBox TextBox83 = null;
		private TextBox TextBox84 = null;
		private TextBox TextBox85 = null;
		private TextBox TextBox86 = null;
		private TextBox TextBox87 = null;
		private TextBox TextBox88 = null;
		private TextBox TextBox89 = null;
		private TextBox TextBox90 = null;
		private TextBox TextBox91 = null;
		private TextBox TextBox92 = null;
		private TextBox TextBox93 = null;
		private TextBox TextBox94 = null;
		private TextBox TextBox95 = null;
		private TextBox TextBox96 = null;
		private TextBox TextBox97 = null;
		private Line Line172 = null;
		private Label Label234 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthlyPolicyProduction));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Line35 = new DataDynamics.ActiveReports.Line();
            this.Line70 = new DataDynamics.ActiveReports.Line();
            this.Line71 = new DataDynamics.ActiveReports.Line();
            this.Line72 = new DataDynamics.ActiveReports.Line();
            this.Line73 = new DataDynamics.ActiveReports.Line();
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
            this.Line86 = new DataDynamics.ActiveReports.Line();
            this.Line87 = new DataDynamics.ActiveReports.Line();
            this.Line88 = new DataDynamics.ActiveReports.Line();
            this.Line89 = new DataDynamics.ActiveReports.Line();
            this.Line90 = new DataDynamics.ActiveReports.Line();
            this.Line91 = new DataDynamics.ActiveReports.Line();
            this.Line92 = new DataDynamics.ActiveReports.Line();
            this.Line93 = new DataDynamics.ActiveReports.Line();
            this.Line94 = new DataDynamics.ActiveReports.Line();
            this.Line95 = new DataDynamics.ActiveReports.Line();
            this.Line96 = new DataDynamics.ActiveReports.Line();
            this.Line97 = new DataDynamics.ActiveReports.Line();
            this.Line98 = new DataDynamics.ActiveReports.Line();
            this.Line99 = new DataDynamics.ActiveReports.Line();
            this.Line100 = new DataDynamics.ActiveReports.Line();
            this.Line101 = new DataDynamics.ActiveReports.Line();
            this.Line102 = new DataDynamics.ActiveReports.Line();
            this.TextBox32 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox33 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox34 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox35 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox36 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox37 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox38 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox39 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox40 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox41 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox42 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox43 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox44 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox45 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox46 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox47 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox48 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox49 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox50 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox51 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox52 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox53 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox54 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox55 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox56 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox57 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox58 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox59 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox60 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox61 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox62 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox63 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox64 = new DataDynamics.ActiveReports.TextBox();
            this.Line136 = new DataDynamics.ActiveReports.Line();
            this.Label133 = new DataDynamics.ActiveReports.Label();
            this.TextBox98 = new DataDynamics.ActiveReports.TextBox();
            this.Line173 = new DataDynamics.ActiveReports.Line();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.Label80 = new DataDynamics.ActiveReports.Label();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.lblTime = new DataDynamics.ActiveReports.Label();
            this.lblCriterias = new DataDynamics.ActiveReports.Label();
            this.Label236 = new DataDynamics.ActiveReports.Label();
            this.Label237 = new DataDynamics.ActiveReports.Label();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.Line137 = new DataDynamics.ActiveReports.Line();
            this.Line138 = new DataDynamics.ActiveReports.Line();
            this.Line139 = new DataDynamics.ActiveReports.Line();
            this.Line140 = new DataDynamics.ActiveReports.Line();
            this.Line141 = new DataDynamics.ActiveReports.Line();
            this.Line142 = new DataDynamics.ActiveReports.Line();
            this.Line143 = new DataDynamics.ActiveReports.Line();
            this.Line144 = new DataDynamics.ActiveReports.Line();
            this.Line145 = new DataDynamics.ActiveReports.Line();
            this.Line146 = new DataDynamics.ActiveReports.Line();
            this.Line147 = new DataDynamics.ActiveReports.Line();
            this.Line148 = new DataDynamics.ActiveReports.Line();
            this.Line149 = new DataDynamics.ActiveReports.Line();
            this.Line150 = new DataDynamics.ActiveReports.Line();
            this.Line151 = new DataDynamics.ActiveReports.Line();
            this.Line152 = new DataDynamics.ActiveReports.Line();
            this.Line153 = new DataDynamics.ActiveReports.Line();
            this.Line154 = new DataDynamics.ActiveReports.Line();
            this.Line155 = new DataDynamics.ActiveReports.Line();
            this.Line156 = new DataDynamics.ActiveReports.Line();
            this.Line157 = new DataDynamics.ActiveReports.Line();
            this.Line158 = new DataDynamics.ActiveReports.Line();
            this.Line159 = new DataDynamics.ActiveReports.Line();
            this.Line160 = new DataDynamics.ActiveReports.Line();
            this.Line161 = new DataDynamics.ActiveReports.Line();
            this.Line162 = new DataDynamics.ActiveReports.Line();
            this.Line163 = new DataDynamics.ActiveReports.Line();
            this.Line164 = new DataDynamics.ActiveReports.Line();
            this.Line165 = new DataDynamics.ActiveReports.Line();
            this.Line166 = new DataDynamics.ActiveReports.Line();
            this.Line167 = new DataDynamics.ActiveReports.Line();
            this.Line168 = new DataDynamics.ActiveReports.Line();
            this.Line169 = new DataDynamics.ActiveReports.Line();
            this.Line170 = new DataDynamics.ActiveReports.Line();
            this.Line171 = new DataDynamics.ActiveReports.Line();
            this.TextBox65 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox66 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox67 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox68 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox69 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox70 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox71 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox72 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox73 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox74 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox75 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox76 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox77 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox78 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox79 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox80 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox81 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox82 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox83 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox84 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox85 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox86 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox87 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox88 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox89 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox90 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox91 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox92 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox93 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox94 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox95 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox96 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox97 = new DataDynamics.ActiveReports.TextBox();
            this.Line172 = new DataDynamics.ActiveReports.Line();
            this.Label234 = new DataDynamics.ActiveReports.Label();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Shape3 = new DataDynamics.ActiveReports.Shape();
            this.Label200 = new DataDynamics.ActiveReports.Label();
            this.Label201 = new DataDynamics.ActiveReports.Label();
            this.Label202 = new DataDynamics.ActiveReports.Label();
            this.Label203 = new DataDynamics.ActiveReports.Label();
            this.Label204 = new DataDynamics.ActiveReports.Label();
            this.Label205 = new DataDynamics.ActiveReports.Label();
            this.Label206 = new DataDynamics.ActiveReports.Label();
            this.Label207 = new DataDynamics.ActiveReports.Label();
            this.Label208 = new DataDynamics.ActiveReports.Label();
            this.Label209 = new DataDynamics.ActiveReports.Label();
            this.Label210 = new DataDynamics.ActiveReports.Label();
            this.Label211 = new DataDynamics.ActiveReports.Label();
            this.Label212 = new DataDynamics.ActiveReports.Label();
            this.Label213 = new DataDynamics.ActiveReports.Label();
            this.Label214 = new DataDynamics.ActiveReports.Label();
            this.Label215 = new DataDynamics.ActiveReports.Label();
            this.Label216 = new DataDynamics.ActiveReports.Label();
            this.Label217 = new DataDynamics.ActiveReports.Label();
            this.Label218 = new DataDynamics.ActiveReports.Label();
            this.Label219 = new DataDynamics.ActiveReports.Label();
            this.Label220 = new DataDynamics.ActiveReports.Label();
            this.Label221 = new DataDynamics.ActiveReports.Label();
            this.Label222 = new DataDynamics.ActiveReports.Label();
            this.Label223 = new DataDynamics.ActiveReports.Label();
            this.Label224 = new DataDynamics.ActiveReports.Label();
            this.Label225 = new DataDynamics.ActiveReports.Label();
            this.Label226 = new DataDynamics.ActiveReports.Label();
            this.Label227 = new DataDynamics.ActiveReports.Label();
            this.Label228 = new DataDynamics.ActiveReports.Label();
            this.Label229 = new DataDynamics.ActiveReports.Label();
            this.Label230 = new DataDynamics.ActiveReports.Label();
            this.Label231 = new DataDynamics.ActiveReports.Label();
            this.Label232 = new DataDynamics.ActiveReports.Label();
            this.Line103 = new DataDynamics.ActiveReports.Line();
            this.Line104 = new DataDynamics.ActiveReports.Line();
            this.Line105 = new DataDynamics.ActiveReports.Line();
            this.Line106 = new DataDynamics.ActiveReports.Line();
            this.Line107 = new DataDynamics.ActiveReports.Line();
            this.Line108 = new DataDynamics.ActiveReports.Line();
            this.Line109 = new DataDynamics.ActiveReports.Line();
            this.Line110 = new DataDynamics.ActiveReports.Line();
            this.Line111 = new DataDynamics.ActiveReports.Line();
            this.Line112 = new DataDynamics.ActiveReports.Line();
            this.Line113 = new DataDynamics.ActiveReports.Line();
            this.Line114 = new DataDynamics.ActiveReports.Line();
            this.Line115 = new DataDynamics.ActiveReports.Line();
            this.Line116 = new DataDynamics.ActiveReports.Line();
            this.Line117 = new DataDynamics.ActiveReports.Line();
            this.Line118 = new DataDynamics.ActiveReports.Line();
            this.Line119 = new DataDynamics.ActiveReports.Line();
            this.Line120 = new DataDynamics.ActiveReports.Line();
            this.Line121 = new DataDynamics.ActiveReports.Line();
            this.Line122 = new DataDynamics.ActiveReports.Line();
            this.Line123 = new DataDynamics.ActiveReports.Line();
            this.Line124 = new DataDynamics.ActiveReports.Line();
            this.Line125 = new DataDynamics.ActiveReports.Line();
            this.Line126 = new DataDynamics.ActiveReports.Line();
            this.Line127 = new DataDynamics.ActiveReports.Line();
            this.Line128 = new DataDynamics.ActiveReports.Line();
            this.Line129 = new DataDynamics.ActiveReports.Line();
            this.Line130 = new DataDynamics.ActiveReports.Line();
            this.Line131 = new DataDynamics.ActiveReports.Line();
            this.Line132 = new DataDynamics.ActiveReports.Line();
            this.Line133 = new DataDynamics.ActiveReports.Line();
            this.Line134 = new DataDynamics.ActiveReports.Line();
            this.Line135 = new DataDynamics.ActiveReports.Line();
            this.Label233 = new DataDynamics.ActiveReports.Label();
            this.Label235 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox98)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label236)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label237)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox79)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox81)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox82)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox83)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox84)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox85)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox86)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox87)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox88)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox89)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox90)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox91)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox92)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox93)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox94)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox95)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox96)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox97)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label234)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label200)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label201)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label202)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label203)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label204)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label205)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label206)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label207)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label208)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label209)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label210)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label211)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label212)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label213)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label214)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label215)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label216)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label217)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label218)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label219)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label220)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label221)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label222)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label223)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label224)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label225)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label226)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label227)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label228)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label229)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label230)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label231)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label232)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label233)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label235)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line35,
            this.Line70,
            this.Line71,
            this.Line72,
            this.Line73,
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
            this.Line86,
            this.Line87,
            this.Line88,
            this.Line89,
            this.Line90,
            this.Line91,
            this.Line92,
            this.Line93,
            this.Line94,
            this.Line95,
            this.Line96,
            this.Line97,
            this.Line98,
            this.Line99,
            this.Line100,
            this.Line101,
            this.Line102,
            this.TextBox32,
            this.TextBox33,
            this.TextBox34,
            this.TextBox35,
            this.TextBox36,
            this.TextBox37,
            this.TextBox38,
            this.TextBox39,
            this.TextBox40,
            this.TextBox41,
            this.TextBox42,
            this.TextBox43,
            this.TextBox44,
            this.TextBox45,
            this.TextBox46,
            this.TextBox47,
            this.TextBox48,
            this.TextBox49,
            this.TextBox50,
            this.TextBox51,
            this.TextBox52,
            this.TextBox53,
            this.TextBox54,
            this.TextBox55,
            this.TextBox56,
            this.TextBox57,
            this.TextBox58,
            this.TextBox59,
            this.TextBox60,
            this.TextBox61,
            this.TextBox62,
            this.TextBox63,
            this.TextBox64,
            this.Line136,
            this.Label133,
            this.TextBox98,
            this.Line173});
            this.Detail.Height = 0.1875F;
            this.Detail.Name = "Detail";
            // 
            // Line35
            // 
            this.Line35.Border.BottomColor = System.Drawing.Color.Black;
            this.Line35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line35.Border.LeftColor = System.Drawing.Color.Black;
            this.Line35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line35.Border.RightColor = System.Drawing.Color.Black;
            this.Line35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line35.Border.TopColor = System.Drawing.Color.Black;
            this.Line35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line35.Height = 0F;
            this.Line35.Left = 0.4444444F;
            this.Line35.LineWeight = 1F;
            this.Line35.Name = "Line35";
            this.Line35.Top = 0.1875F;
            this.Line35.Width = 12.93056F;
            this.Line35.X1 = 0.4444444F;
            this.Line35.X2 = 13.375F;
            this.Line35.Y1 = 0.1875F;
            this.Line35.Y2 = 0.1875F;
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
            this.Line70.Height = 0.1875F;
            this.Line70.Left = 2.694444F;
            this.Line70.LineWeight = 1F;
            this.Line70.Name = "Line70";
            this.Line70.Top = 0.006944358F;
            this.Line70.Width = 0F;
            this.Line70.X1 = 2.694444F;
            this.Line70.X2 = 2.694444F;
            this.Line70.Y1 = 0.006944358F;
            this.Line70.Y2 = 0.1944444F;
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
            this.Line71.Height = 0.1875F;
            this.Line71.Left = 3.006944F;
            this.Line71.LineWeight = 1F;
            this.Line71.Name = "Line71";
            this.Line71.Top = 0.006944358F;
            this.Line71.Width = 0F;
            this.Line71.X1 = 3.006944F;
            this.Line71.X2 = 3.006944F;
            this.Line71.Y1 = 0.006944358F;
            this.Line71.Y2 = 0.1944444F;
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
            this.Line72.Height = 0.1875F;
            this.Line72.Left = 3.319444F;
            this.Line72.LineWeight = 1F;
            this.Line72.Name = "Line72";
            this.Line72.Top = 0.006944358F;
            this.Line72.Width = 0F;
            this.Line72.X1 = 3.319444F;
            this.Line72.X2 = 3.319444F;
            this.Line72.Y1 = 0.006944358F;
            this.Line72.Y2 = 0.1944444F;
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
            this.Line73.Height = 0.1875F;
            this.Line73.Left = 3.631944F;
            this.Line73.LineWeight = 1F;
            this.Line73.Name = "Line73";
            this.Line73.Top = 0.006944358F;
            this.Line73.Width = 0F;
            this.Line73.X1 = 3.631944F;
            this.Line73.X2 = 3.631944F;
            this.Line73.Y1 = 0.006944358F;
            this.Line73.Y2 = 0.1944444F;
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
            this.Line74.Height = 0.1875F;
            this.Line74.Left = 3.944444F;
            this.Line74.LineWeight = 1F;
            this.Line74.Name = "Line74";
            this.Line74.Top = 0.006944358F;
            this.Line74.Width = 0F;
            this.Line74.X1 = 3.944444F;
            this.Line74.X2 = 3.944444F;
            this.Line74.Y1 = 0.006944358F;
            this.Line74.Y2 = 0.1944444F;
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
            this.Line75.Height = 0.1875F;
            this.Line75.Left = 4.256945F;
            this.Line75.LineWeight = 1F;
            this.Line75.Name = "Line75";
            this.Line75.Top = 0.006944358F;
            this.Line75.Width = 0F;
            this.Line75.X1 = 4.256945F;
            this.Line75.X2 = 4.256945F;
            this.Line75.Y1 = 0.006944358F;
            this.Line75.Y2 = 0.1944444F;
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
            this.Line76.Height = 0.1875F;
            this.Line76.Left = 4.569445F;
            this.Line76.LineWeight = 1F;
            this.Line76.Name = "Line76";
            this.Line76.Top = 0.006944358F;
            this.Line76.Width = 0F;
            this.Line76.X1 = 4.569445F;
            this.Line76.X2 = 4.569445F;
            this.Line76.Y1 = 0.006944358F;
            this.Line76.Y2 = 0.1944444F;
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
            this.Line77.Height = 0.1875F;
            this.Line77.Left = 4.881945F;
            this.Line77.LineWeight = 1F;
            this.Line77.Name = "Line77";
            this.Line77.Top = 0.006944358F;
            this.Line77.Width = 0F;
            this.Line77.X1 = 4.881945F;
            this.Line77.X2 = 4.881945F;
            this.Line77.Y1 = 0.006944358F;
            this.Line77.Y2 = 0.1944444F;
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
            this.Line78.Height = 0.1875F;
            this.Line78.Left = 5.506945F;
            this.Line78.LineWeight = 1F;
            this.Line78.Name = "Line78";
            this.Line78.Top = 0.006944358F;
            this.Line78.Width = 0F;
            this.Line78.X1 = 5.506945F;
            this.Line78.X2 = 5.506945F;
            this.Line78.Y1 = 0.006944358F;
            this.Line78.Y2 = 0.1944444F;
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
            this.Line79.Height = 0.1875F;
            this.Line79.Left = 5.194445F;
            this.Line79.LineWeight = 1F;
            this.Line79.Name = "Line79";
            this.Line79.Top = 0.006944358F;
            this.Line79.Width = 0F;
            this.Line79.X1 = 5.194445F;
            this.Line79.X2 = 5.194445F;
            this.Line79.Y1 = 0.006944358F;
            this.Line79.Y2 = 0.1944444F;
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
            this.Line80.Height = 0.1875F;
            this.Line80.Left = 5.819445F;
            this.Line80.LineWeight = 1F;
            this.Line80.Name = "Line80";
            this.Line80.Top = 0.006944358F;
            this.Line80.Width = 0F;
            this.Line80.X1 = 5.819445F;
            this.Line80.X2 = 5.819445F;
            this.Line80.Y1 = 0.006944358F;
            this.Line80.Y2 = 0.1944444F;
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
            this.Line81.Height = 0.1875F;
            this.Line81.Left = 6.131945F;
            this.Line81.LineWeight = 1F;
            this.Line81.Name = "Line81";
            this.Line81.Top = 0.006944358F;
            this.Line81.Width = 0F;
            this.Line81.X1 = 6.131945F;
            this.Line81.X2 = 6.131945F;
            this.Line81.Y1 = 0.006944358F;
            this.Line81.Y2 = 0.1944444F;
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
            this.Line82.Height = 0.1875F;
            this.Line82.Left = 6.444445F;
            this.Line82.LineWeight = 1F;
            this.Line82.Name = "Line82";
            this.Line82.Top = 0.006944358F;
            this.Line82.Width = 0F;
            this.Line82.X1 = 6.444445F;
            this.Line82.X2 = 6.444445F;
            this.Line82.Y1 = 0.006944358F;
            this.Line82.Y2 = 0.1944444F;
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
            this.Line83.Height = 0.1875F;
            this.Line83.Left = 6.756945F;
            this.Line83.LineWeight = 1F;
            this.Line83.Name = "Line83";
            this.Line83.Top = 0.006944358F;
            this.Line83.Width = 0F;
            this.Line83.X1 = 6.756945F;
            this.Line83.X2 = 6.756945F;
            this.Line83.Y1 = 0.006944358F;
            this.Line83.Y2 = 0.1944444F;
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
            this.Line84.Height = 0.1875F;
            this.Line84.Left = 7.069445F;
            this.Line84.LineWeight = 1F;
            this.Line84.Name = "Line84";
            this.Line84.Top = 0.006944358F;
            this.Line84.Width = 0F;
            this.Line84.X1 = 7.069445F;
            this.Line84.X2 = 7.069445F;
            this.Line84.Y1 = 0.006944358F;
            this.Line84.Y2 = 0.1944444F;
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
            this.Line85.Height = 0.1875F;
            this.Line85.Left = 7.381945F;
            this.Line85.LineWeight = 1F;
            this.Line85.Name = "Line85";
            this.Line85.Top = 0.006944358F;
            this.Line85.Width = 0F;
            this.Line85.X1 = 7.381945F;
            this.Line85.X2 = 7.381945F;
            this.Line85.Y1 = 0.006944358F;
            this.Line85.Y2 = 0.1944444F;
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
            this.Line86.Height = 0.1875F;
            this.Line86.Left = 7.694445F;
            this.Line86.LineWeight = 1F;
            this.Line86.Name = "Line86";
            this.Line86.Top = 0.006944358F;
            this.Line86.Width = 0F;
            this.Line86.X1 = 7.694445F;
            this.Line86.X2 = 7.694445F;
            this.Line86.Y1 = 0.006944358F;
            this.Line86.Y2 = 0.1944444F;
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
            this.Line87.Height = 0.1875F;
            this.Line87.Left = 8.006945F;
            this.Line87.LineWeight = 1F;
            this.Line87.Name = "Line87";
            this.Line87.Top = 0.006944358F;
            this.Line87.Width = 0F;
            this.Line87.X1 = 8.006945F;
            this.Line87.X2 = 8.006945F;
            this.Line87.Y1 = 0.006944358F;
            this.Line87.Y2 = 0.1944444F;
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
            this.Line88.Height = 0.1875F;
            this.Line88.Left = 8.319445F;
            this.Line88.LineWeight = 1F;
            this.Line88.Name = "Line88";
            this.Line88.Top = 0.006944358F;
            this.Line88.Width = 0F;
            this.Line88.X1 = 8.319445F;
            this.Line88.X2 = 8.319445F;
            this.Line88.Y1 = 0.006944358F;
            this.Line88.Y2 = 0.1944444F;
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
            this.Line89.Height = 0.1875F;
            this.Line89.Left = 8.631945F;
            this.Line89.LineWeight = 1F;
            this.Line89.Name = "Line89";
            this.Line89.Top = 0.006944358F;
            this.Line89.Width = 0F;
            this.Line89.X1 = 8.631945F;
            this.Line89.X2 = 8.631945F;
            this.Line89.Y1 = 0.006944358F;
            this.Line89.Y2 = 0.1944444F;
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
            this.Line90.Height = 0.1875F;
            this.Line90.Left = 8.944445F;
            this.Line90.LineWeight = 1F;
            this.Line90.Name = "Line90";
            this.Line90.Top = 0.006944358F;
            this.Line90.Width = 0F;
            this.Line90.X1 = 8.944445F;
            this.Line90.X2 = 8.944445F;
            this.Line90.Y1 = 0.006944358F;
            this.Line90.Y2 = 0.1944444F;
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
            this.Line91.Height = 0.1875F;
            this.Line91.Left = 9.256945F;
            this.Line91.LineWeight = 1F;
            this.Line91.Name = "Line91";
            this.Line91.Top = 0.006944358F;
            this.Line91.Width = 0F;
            this.Line91.X1 = 9.256945F;
            this.Line91.X2 = 9.256945F;
            this.Line91.Y1 = 0.006944358F;
            this.Line91.Y2 = 0.1944444F;
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
            this.Line92.Height = 0.1875F;
            this.Line92.Left = 9.569445F;
            this.Line92.LineWeight = 1F;
            this.Line92.Name = "Line92";
            this.Line92.Top = 0.006944358F;
            this.Line92.Width = 0F;
            this.Line92.X1 = 9.569445F;
            this.Line92.X2 = 9.569445F;
            this.Line92.Y1 = 0.006944358F;
            this.Line92.Y2 = 0.1944444F;
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
            this.Line93.Height = 0.1875F;
            this.Line93.Left = 9.881945F;
            this.Line93.LineWeight = 1F;
            this.Line93.Name = "Line93";
            this.Line93.Top = 0.006944358F;
            this.Line93.Width = 0F;
            this.Line93.X1 = 9.881945F;
            this.Line93.X2 = 9.881945F;
            this.Line93.Y1 = 0.006944358F;
            this.Line93.Y2 = 0.1944444F;
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
            this.Line94.Height = 0.1875F;
            this.Line94.Left = 10.19444F;
            this.Line94.LineWeight = 1F;
            this.Line94.Name = "Line94";
            this.Line94.Top = 0.006944358F;
            this.Line94.Width = 0F;
            this.Line94.X1 = 10.19444F;
            this.Line94.X2 = 10.19444F;
            this.Line94.Y1 = 0.006944358F;
            this.Line94.Y2 = 0.1944444F;
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
            this.Line95.Height = 0.1875F;
            this.Line95.Left = 10.50694F;
            this.Line95.LineWeight = 1F;
            this.Line95.Name = "Line95";
            this.Line95.Top = 0.006944358F;
            this.Line95.Width = 0F;
            this.Line95.X1 = 10.50694F;
            this.Line95.X2 = 10.50694F;
            this.Line95.Y1 = 0.006944358F;
            this.Line95.Y2 = 0.1944444F;
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
            this.Line96.Height = 0.1875F;
            this.Line96.Left = 11.13194F;
            this.Line96.LineWeight = 1F;
            this.Line96.Name = "Line96";
            this.Line96.Top = 0.006944358F;
            this.Line96.Width = 0F;
            this.Line96.X1 = 11.13194F;
            this.Line96.X2 = 11.13194F;
            this.Line96.Y1 = 0.006944358F;
            this.Line96.Y2 = 0.1944444F;
            // 
            // Line97
            // 
            this.Line97.Border.BottomColor = System.Drawing.Color.Black;
            this.Line97.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line97.Border.LeftColor = System.Drawing.Color.Black;
            this.Line97.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line97.Border.RightColor = System.Drawing.Color.Black;
            this.Line97.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line97.Border.TopColor = System.Drawing.Color.Black;
            this.Line97.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line97.Height = 0.1875F;
            this.Line97.Left = 12.75694F;
            this.Line97.LineWeight = 1F;
            this.Line97.Name = "Line97";
            this.Line97.Top = 0.006944358F;
            this.Line97.Width = 0F;
            this.Line97.X1 = 12.75694F;
            this.Line97.X2 = 12.75694F;
            this.Line97.Y1 = 0.006944358F;
            this.Line97.Y2 = 0.1944444F;
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
            this.Line98.Height = 0.1875F;
            this.Line98.Left = 12.06944F;
            this.Line98.LineWeight = 1F;
            this.Line98.Name = "Line98";
            this.Line98.Top = 0.006944358F;
            this.Line98.Width = 0F;
            this.Line98.X1 = 12.06944F;
            this.Line98.X2 = 12.06944F;
            this.Line98.Y1 = 0.006944358F;
            this.Line98.Y2 = 0.1944444F;
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
            this.Line99.Height = 0.1875F;
            this.Line99.Left = 11.75694F;
            this.Line99.LineWeight = 1F;
            this.Line99.Name = "Line99";
            this.Line99.Top = 0.006944358F;
            this.Line99.Width = 0F;
            this.Line99.X1 = 11.75694F;
            this.Line99.X2 = 11.75694F;
            this.Line99.Y1 = 0.006944358F;
            this.Line99.Y2 = 0.1944444F;
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
            this.Line100.Height = 0.1875F;
            this.Line100.Left = 11.44444F;
            this.Line100.LineWeight = 1F;
            this.Line100.Name = "Line100";
            this.Line100.Top = 0.006944358F;
            this.Line100.Width = 0F;
            this.Line100.X1 = 11.44444F;
            this.Line100.X2 = 11.44444F;
            this.Line100.Y1 = 0.006944358F;
            this.Line100.Y2 = 0.1944444F;
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
            this.Line101.Height = 0.1875F;
            this.Line101.Left = 10.81944F;
            this.Line101.LineWeight = 1F;
            this.Line101.Name = "Line101";
            this.Line101.Top = 0.006944358F;
            this.Line101.Width = 0F;
            this.Line101.X1 = 10.81944F;
            this.Line101.X2 = 10.81944F;
            this.Line101.Y1 = 0.006944358F;
            this.Line101.Y2 = 0.1944444F;
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
            this.Line102.Height = 0.1875F;
            this.Line102.Left = 2.381944F;
            this.Line102.LineWeight = 1F;
            this.Line102.Name = "Line102";
            this.Line102.Top = 0.006944358F;
            this.Line102.Width = 0F;
            this.Line102.X1 = 2.381944F;
            this.Line102.X2 = 2.381944F;
            this.Line102.Y1 = 0.006944358F;
            this.Line102.Y2 = 0.1944444F;
            // 
            // TextBox32
            // 
            this.TextBox32.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.DataField = "DIA_1";
            this.TextBox32.Height = 0.2F;
            this.TextBox32.Left = 2.4375F;
            this.TextBox32.Name = "TextBox32";
            this.TextBox32.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox32.Text = null;
            this.TextBox32.Top = 0F;
            this.TextBox32.Width = 0.25F;
            // 
            // TextBox33
            // 
            this.TextBox33.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.DataField = "DIA_2";
            this.TextBox33.Height = 0.2F;
            this.TextBox33.Left = 2.75F;
            this.TextBox33.Name = "TextBox33";
            this.TextBox33.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox33.Text = null;
            this.TextBox33.Top = 0F;
            this.TextBox33.Width = 0.25F;
            // 
            // TextBox34
            // 
            this.TextBox34.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox34.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox34.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox34.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox34.DataField = "DIA_3";
            this.TextBox34.Height = 0.2F;
            this.TextBox34.Left = 3.0625F;
            this.TextBox34.Name = "TextBox34";
            this.TextBox34.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox34.Text = null;
            this.TextBox34.Top = 0F;
            this.TextBox34.Width = 0.25F;
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
            this.TextBox35.DataField = "DIA_4";
            this.TextBox35.Height = 0.2F;
            this.TextBox35.Left = 3.375F;
            this.TextBox35.Name = "TextBox35";
            this.TextBox35.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox35.Text = null;
            this.TextBox35.Top = 0F;
            this.TextBox35.Width = 0.25F;
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
            this.TextBox36.DataField = "DIA_5";
            this.TextBox36.Height = 0.2F;
            this.TextBox36.Left = 3.625F;
            this.TextBox36.Name = "TextBox36";
            this.TextBox36.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox36.Text = null;
            this.TextBox36.Top = 0F;
            this.TextBox36.Width = 0.25F;
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
            this.TextBox37.DataField = "DIA_6";
            this.TextBox37.Height = 0.2F;
            this.TextBox37.Left = 4F;
            this.TextBox37.Name = "TextBox37";
            this.TextBox37.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox37.Text = null;
            this.TextBox37.Top = 0F;
            this.TextBox37.Width = 0.25F;
            // 
            // TextBox38
            // 
            this.TextBox38.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox38.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox38.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox38.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox38.DataField = "DIA_7";
            this.TextBox38.Height = 0.2F;
            this.TextBox38.Left = 4.3125F;
            this.TextBox38.Name = "TextBox38";
            this.TextBox38.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox38.Text = null;
            this.TextBox38.Top = 0F;
            this.TextBox38.Width = 0.25F;
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
            this.TextBox39.DataField = "DIA_8";
            this.TextBox39.Height = 0.2F;
            this.TextBox39.Left = 4.625F;
            this.TextBox39.Name = "TextBox39";
            this.TextBox39.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox39.Text = null;
            this.TextBox39.Top = 0F;
            this.TextBox39.Width = 0.25F;
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
            this.TextBox40.DataField = "DIA_9";
            this.TextBox40.Height = 0.2F;
            this.TextBox40.Left = 4.9375F;
            this.TextBox40.Name = "TextBox40";
            this.TextBox40.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox40.Text = null;
            this.TextBox40.Top = 0F;
            this.TextBox40.Width = 0.25F;
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
            this.TextBox41.DataField = "DIA_10";
            this.TextBox41.Height = 0.2F;
            this.TextBox41.Left = 5.25F;
            this.TextBox41.Name = "TextBox41";
            this.TextBox41.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox41.Text = null;
            this.TextBox41.Top = 0F;
            this.TextBox41.Width = 0.25F;
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
            this.TextBox42.DataField = "DIA_11";
            this.TextBox42.Height = 0.2F;
            this.TextBox42.Left = 5.5625F;
            this.TextBox42.Name = "TextBox42";
            this.TextBox42.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox42.Text = null;
            this.TextBox42.Top = 0F;
            this.TextBox42.Width = 0.25F;
            // 
            // TextBox43
            // 
            this.TextBox43.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox43.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox43.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox43.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox43.DataField = "DIA_12";
            this.TextBox43.Height = 0.2F;
            this.TextBox43.Left = 5.875F;
            this.TextBox43.Name = "TextBox43";
            this.TextBox43.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox43.Text = null;
            this.TextBox43.Top = 0F;
            this.TextBox43.Width = 0.25F;
            // 
            // TextBox44
            // 
            this.TextBox44.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox44.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox44.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox44.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox44.DataField = "DIA_13";
            this.TextBox44.Height = 0.2F;
            this.TextBox44.Left = 6.1875F;
            this.TextBox44.Name = "TextBox44";
            this.TextBox44.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox44.Text = null;
            this.TextBox44.Top = 0F;
            this.TextBox44.Width = 0.25F;
            // 
            // TextBox45
            // 
            this.TextBox45.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox45.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox45.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox45.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox45.DataField = "DIA_14";
            this.TextBox45.Height = 0.2F;
            this.TextBox45.Left = 6.5F;
            this.TextBox45.Name = "TextBox45";
            this.TextBox45.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox45.Text = null;
            this.TextBox45.Top = 0F;
            this.TextBox45.Width = 0.25F;
            // 
            // TextBox46
            // 
            this.TextBox46.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox46.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox46.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox46.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox46.DataField = "DIA_15";
            this.TextBox46.Height = 0.2F;
            this.TextBox46.Left = 6.75F;
            this.TextBox46.Name = "TextBox46";
            this.TextBox46.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox46.Text = null;
            this.TextBox46.Top = 0F;
            this.TextBox46.Width = 0.25F;
            // 
            // TextBox47
            // 
            this.TextBox47.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox47.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox47.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox47.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox47.DataField = "DIA_16";
            this.TextBox47.Height = 0.2F;
            this.TextBox47.Left = 7.125F;
            this.TextBox47.Name = "TextBox47";
            this.TextBox47.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox47.Text = null;
            this.TextBox47.Top = 0F;
            this.TextBox47.Width = 0.25F;
            // 
            // TextBox48
            // 
            this.TextBox48.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox48.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox48.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox48.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox48.DataField = "DIA_17";
            this.TextBox48.Height = 0.2F;
            this.TextBox48.Left = 7.4375F;
            this.TextBox48.Name = "TextBox48";
            this.TextBox48.Style = "text-align: center; font-size: 7pt; vertical-align: top; ";
            this.TextBox48.Text = null;
            this.TextBox48.Top = 0F;
            this.TextBox48.Width = 0.25F;
            // 
            // TextBox49
            // 
            this.TextBox49.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox49.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox49.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox49.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox49.DataField = "DIA_18";
            this.TextBox49.Height = 0.2F;
            this.TextBox49.Left = 7.75F;
            this.TextBox49.Name = "TextBox49";
            this.TextBox49.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox49.Text = null;
            this.TextBox49.Top = 0F;
            this.TextBox49.Width = 0.25F;
            // 
            // TextBox50
            // 
            this.TextBox50.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox50.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox50.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox50.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox50.DataField = "DIA_19";
            this.TextBox50.Height = 0.2F;
            this.TextBox50.Left = 8.0625F;
            this.TextBox50.Name = "TextBox50";
            this.TextBox50.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox50.Text = null;
            this.TextBox50.Top = 0F;
            this.TextBox50.Width = 0.25F;
            // 
            // TextBox51
            // 
            this.TextBox51.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox51.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox51.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox51.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox51.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox51.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox51.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox51.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox51.DataField = "DIA_20";
            this.TextBox51.Height = 0.2F;
            this.TextBox51.Left = 8.375F;
            this.TextBox51.Name = "TextBox51";
            this.TextBox51.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox51.Text = null;
            this.TextBox51.Top = 0F;
            this.TextBox51.Width = 0.25F;
            // 
            // TextBox52
            // 
            this.TextBox52.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox52.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox52.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox52.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox52.DataField = "DIA_21";
            this.TextBox52.Height = 0.2F;
            this.TextBox52.Left = 8.6875F;
            this.TextBox52.Name = "TextBox52";
            this.TextBox52.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox52.Text = null;
            this.TextBox52.Top = 0F;
            this.TextBox52.Width = 0.25F;
            // 
            // TextBox53
            // 
            this.TextBox53.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox53.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox53.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox53.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox53.DataField = "DIA_22";
            this.TextBox53.Height = 0.2F;
            this.TextBox53.Left = 9F;
            this.TextBox53.Name = "TextBox53";
            this.TextBox53.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox53.Text = null;
            this.TextBox53.Top = 0F;
            this.TextBox53.Width = 0.25F;
            // 
            // TextBox54
            // 
            this.TextBox54.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox54.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox54.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox54.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox54.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox54.DataField = "DIA_23";
            this.TextBox54.Height = 0.2F;
            this.TextBox54.Left = 9.3125F;
            this.TextBox54.Name = "TextBox54";
            this.TextBox54.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox54.Text = null;
            this.TextBox54.Top = 0F;
            this.TextBox54.Width = 0.25F;
            // 
            // TextBox55
            // 
            this.TextBox55.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox55.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox55.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox55.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox55.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox55.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox55.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox55.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox55.DataField = "DIA_24";
            this.TextBox55.Height = 0.2F;
            this.TextBox55.Left = 9.625F;
            this.TextBox55.Name = "TextBox55";
            this.TextBox55.Style = "text-align: center; font-size: 7pt; vertical-align: top; ";
            this.TextBox55.Text = null;
            this.TextBox55.Top = 0F;
            this.TextBox55.Width = 0.25F;
            // 
            // TextBox56
            // 
            this.TextBox56.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox56.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox56.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox56.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox56.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox56.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox56.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox56.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox56.DataField = "DIA_25";
            this.TextBox56.Height = 0.2F;
            this.TextBox56.Left = 9.9375F;
            this.TextBox56.Name = "TextBox56";
            this.TextBox56.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox56.Text = null;
            this.TextBox56.Top = 0F;
            this.TextBox56.Width = 0.25F;
            // 
            // TextBox57
            // 
            this.TextBox57.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox57.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox57.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox57.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox57.DataField = "DIA_26";
            this.TextBox57.Height = 0.2F;
            this.TextBox57.Left = 10.25F;
            this.TextBox57.Name = "TextBox57";
            this.TextBox57.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox57.Text = null;
            this.TextBox57.Top = 0F;
            this.TextBox57.Width = 0.25F;
            // 
            // TextBox58
            // 
            this.TextBox58.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox58.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox58.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox58.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox58.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox58.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox58.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox58.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox58.DataField = "DIA_27";
            this.TextBox58.Height = 0.2F;
            this.TextBox58.Left = 10.5625F;
            this.TextBox58.Name = "TextBox58";
            this.TextBox58.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox58.Text = null;
            this.TextBox58.Top = 0F;
            this.TextBox58.Width = 0.25F;
            // 
            // TextBox59
            // 
            this.TextBox59.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox59.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox59.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox59.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox59.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox59.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox59.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox59.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox59.DataField = "DIA_28";
            this.TextBox59.Height = 0.2F;
            this.TextBox59.Left = 10.875F;
            this.TextBox59.Name = "TextBox59";
            this.TextBox59.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox59.Text = null;
            this.TextBox59.Top = 0F;
            this.TextBox59.Width = 0.25F;
            // 
            // TextBox60
            // 
            this.TextBox60.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox60.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox60.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox60.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox60.DataField = "DIA_29";
            this.TextBox60.Height = 0.2F;
            this.TextBox60.Left = 11.1875F;
            this.TextBox60.Name = "TextBox60";
            this.TextBox60.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox60.Text = null;
            this.TextBox60.Top = 0F;
            this.TextBox60.Width = 0.25F;
            // 
            // TextBox61
            // 
            this.TextBox61.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox61.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox61.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox61.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox61.DataField = "DIA_30";
            this.TextBox61.Height = 0.2F;
            this.TextBox61.Left = 11.5F;
            this.TextBox61.Name = "TextBox61";
            this.TextBox61.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox61.Text = null;
            this.TextBox61.Top = 0F;
            this.TextBox61.Width = 0.25F;
            // 
            // TextBox62
            // 
            this.TextBox62.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox62.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox62.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox62.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox62.DataField = "DIA_31";
            this.TextBox62.Height = 0.2F;
            this.TextBox62.Left = 11.8125F;
            this.TextBox62.Name = "TextBox62";
            this.TextBox62.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox62.Text = null;
            this.TextBox62.Top = 0F;
            this.TextBox62.Width = 0.25F;
            // 
            // TextBox63
            // 
            this.TextBox63.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox63.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox63.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox63.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox63.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox63.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox63.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox63.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox63.DataField = "Total_cantidad";
            this.TextBox63.Height = 0.2F;
            this.TextBox63.Left = 12.125F;
            this.TextBox63.Name = "TextBox63";
            this.TextBox63.OutputFormat = resources.GetString("TextBox63.OutputFormat");
            this.TextBox63.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox63.Text = null;
            this.TextBox63.Top = 0F;
            this.TextBox63.Width = 0.625F;
            // 
            // TextBox64
            // 
            this.TextBox64.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox64.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox64.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox64.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox64.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox64.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox64.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox64.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox64.DataField = "Mes_Anterior";
            this.TextBox64.Height = 0.2F;
            this.TextBox64.Left = 12.75F;
            this.TextBox64.Name = "TextBox64";
            this.TextBox64.OutputFormat = resources.GetString("TextBox64.OutputFormat");
            this.TextBox64.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox64.Text = null;
            this.TextBox64.Top = 0F;
            this.TextBox64.Width = 0.5625F;
            // 
            // Line136
            // 
            this.Line136.Border.BottomColor = System.Drawing.Color.Black;
            this.Line136.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line136.Border.LeftColor = System.Drawing.Color.Black;
            this.Line136.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line136.Border.RightColor = System.Drawing.Color.Black;
            this.Line136.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line136.Border.TopColor = System.Drawing.Color.Black;
            this.Line136.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line136.Height = 0.1875F;
            this.Line136.Left = 13.375F;
            this.Line136.LineWeight = 1F;
            this.Line136.Name = "Line136";
            this.Line136.Top = 0.006944444F;
            this.Line136.Width = 0F;
            this.Line136.X1 = 13.375F;
            this.Line136.X2 = 13.375F;
            this.Line136.Y1 = 0.006944444F;
            this.Line136.Y2 = 0.1944444F;
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
            this.Label133.DataField = "CompanyDealerDesc";
            this.Label133.Height = 0.2F;
            this.Label133.HyperLink = "";
            this.Label133.Left = 0.5F;
            this.Label133.Name = "Label133";
            this.Label133.Style = "text-align: left; font-weight: bold; font-size: 7pt; ";
            this.Label133.Text = "";
            this.Label133.Top = 0F;
            this.Label133.Width = 1.5F;
            // 
            // TextBox98
            // 
            this.TextBox98.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox98.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox98.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox98.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox98.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox98.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox98.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox98.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox98.DataField = "CompanyDealerID";
            this.TextBox98.Height = 0.2F;
            this.TextBox98.Left = 2.0625F;
            this.TextBox98.Name = "TextBox98";
            this.TextBox98.Style = "text-align: left; font-size: 7pt; ";
            this.TextBox98.Text = null;
            this.TextBox98.Top = 0F;
            this.TextBox98.Width = 0.3375001F;
            // 
            // Line173
            // 
            this.Line173.Border.BottomColor = System.Drawing.Color.Black;
            this.Line173.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line173.Border.LeftColor = System.Drawing.Color.Black;
            this.Line173.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line173.Border.RightColor = System.Drawing.Color.Black;
            this.Line173.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line173.Border.TopColor = System.Drawing.Color.Black;
            this.Line173.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line173.Height = 0.1875F;
            this.Line173.Left = 0.4375F;
            this.Line173.LineWeight = 1F;
            this.Line173.Name = "Line173";
            this.Line173.Top = 0.006944358F;
            this.Line173.Width = 0F;
            this.Line173.X1 = 0.4375F;
            this.Line173.X2 = 0.4375F;
            this.Line173.Y1 = 0.006944358F;
            this.Line173.Y2 = 0.1944444F;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label80,
            this.lblDate,
            this.lblTime,
            this.lblCriterias,
            this.Label236,
            this.Label237,
            this.TextBox17});
            this.ReportHeader.Height = 1.375F;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.Format += new System.EventHandler(this.ReportHeader_Format);
            // 
            // Label80
            // 
            this.Label80.Border.BottomColor = System.Drawing.Color.Black;
            this.Label80.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label80.Border.LeftColor = System.Drawing.Color.Black;
            this.Label80.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label80.Border.RightColor = System.Drawing.Color.Black;
            this.Label80.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label80.Border.TopColor = System.Drawing.Color.Black;
            this.Label80.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label80.Height = 0.1875F;
            this.Label80.HyperLink = "";
            this.Label80.Left = 11.6875F;
            this.Label80.Name = "Label80";
            this.Label80.Style = "text-align: right; font-size: 8pt; ";
            this.Label80.Text = "Page";
            this.Label80.Top = 0.0625F;
            this.Label80.Width = 0.5F;
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
            this.lblDate.Left = 0.25F;
            this.lblDate.Name = "lblDate";
            this.lblDate.Style = "text-align: left; font-size: 8pt; ";
            this.lblDate.Text = "lblDate";
            this.lblDate.Top = 0.0625F;
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
            this.lblTime.Left = 0.25F;
            this.lblTime.Name = "lblTime";
            this.lblTime.Style = "text-align: left; font-size: 8pt; ";
            this.lblTime.Text = "lblTime";
            this.lblTime.Top = 0.25F;
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
            this.lblCriterias.Left = 4.1875F;
            this.lblCriterias.MultiLine = false;
            this.lblCriterias.Name = "lblCriterias";
            this.lblCriterias.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 10pt; ";
            this.lblCriterias.Text = "";
            this.lblCriterias.Top = 0.8125F;
            this.lblCriterias.Width = 5.125F;
            // 
            // Label236
            // 
            this.Label236.Border.BottomColor = System.Drawing.Color.Black;
            this.Label236.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label236.Border.LeftColor = System.Drawing.Color.Black;
            this.Label236.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label236.Border.RightColor = System.Drawing.Color.Black;
            this.Label236.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label236.Border.TopColor = System.Drawing.Color.Black;
            this.Label236.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label236.Height = 0.1875F;
            this.Label236.HyperLink = "";
            this.Label236.Left = 4.1875F;
            this.Label236.MultiLine = false;
            this.Label236.Name = "Label236";
            this.Label236.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 12pt; ";
            this.Label236.Text = "";
            this.Label236.Top = 0.3125F;
            this.Label236.Width = 5.125F;
            // 
            // Label237
            // 
            this.Label237.Border.BottomColor = System.Drawing.Color.Black;
            this.Label237.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label237.Border.LeftColor = System.Drawing.Color.Black;
            this.Label237.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label237.Border.RightColor = System.Drawing.Color.Black;
            this.Label237.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label237.Border.TopColor = System.Drawing.Color.Black;
            this.Label237.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label237.Height = 0.1875F;
            this.Label237.HyperLink = "";
            this.Label237.Left = 4.1875F;
            this.Label237.MultiLine = false;
            this.Label237.Name = "Label237";
            this.Label237.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 10pt; ";
            this.Label237.Text = "MONTHLY REPORT";
            this.Label237.Top = 0.5625F;
            this.Label237.Width = 5.125F;
            // 
            // TextBox17
            // 
            this.TextBox17.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Height = 0.1875F;
            this.TextBox17.Left = 12.1875F;
            this.TextBox17.MultiLine = false;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "text-align: right; font-size: 8pt; vertical-align: top; ";
            this.TextBox17.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.TextBox17.Text = null;
            this.TextBox17.Top = 0.0625F;
            this.TextBox17.Width = 0.322917F;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line137,
            this.Line138,
            this.Line139,
            this.Line140,
            this.Line141,
            this.Line142,
            this.Line143,
            this.Line144,
            this.Line145,
            this.Line146,
            this.Line147,
            this.Line148,
            this.Line149,
            this.Line150,
            this.Line151,
            this.Line152,
            this.Line153,
            this.Line154,
            this.Line155,
            this.Line156,
            this.Line157,
            this.Line158,
            this.Line159,
            this.Line160,
            this.Line161,
            this.Line162,
            this.Line163,
            this.Line164,
            this.Line165,
            this.Line166,
            this.Line167,
            this.Line168,
            this.Line169,
            this.Line170,
            this.Line171,
            this.TextBox65,
            this.TextBox66,
            this.TextBox67,
            this.TextBox68,
            this.TextBox69,
            this.TextBox70,
            this.TextBox71,
            this.TextBox72,
            this.TextBox73,
            this.TextBox74,
            this.TextBox75,
            this.TextBox76,
            this.TextBox77,
            this.TextBox78,
            this.TextBox79,
            this.TextBox80,
            this.TextBox81,
            this.TextBox82,
            this.TextBox83,
            this.TextBox84,
            this.TextBox85,
            this.TextBox86,
            this.TextBox87,
            this.TextBox88,
            this.TextBox89,
            this.TextBox90,
            this.TextBox91,
            this.TextBox92,
            this.TextBox93,
            this.TextBox94,
            this.TextBox95,
            this.TextBox96,
            this.TextBox97,
            this.Line172,
            this.Label234});
            this.ReportFooter.Height = 0.625F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // Line137
            // 
            this.Line137.Border.BottomColor = System.Drawing.Color.Black;
            this.Line137.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line137.Border.LeftColor = System.Drawing.Color.Black;
            this.Line137.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line137.Border.RightColor = System.Drawing.Color.Black;
            this.Line137.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line137.Border.TopColor = System.Drawing.Color.Black;
            this.Line137.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line137.Height = 0.1875F;
            this.Line137.Left = 0.4375F;
            this.Line137.LineWeight = 1F;
            this.Line137.Name = "Line137";
            this.Line137.Top = 0.006944444F;
            this.Line137.Width = 0F;
            this.Line137.X1 = 0.4375F;
            this.Line137.X2 = 0.4375F;
            this.Line137.Y1 = 0.006944444F;
            this.Line137.Y2 = 0.1944444F;
            // 
            // Line138
            // 
            this.Line138.Border.BottomColor = System.Drawing.Color.Black;
            this.Line138.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line138.Border.LeftColor = System.Drawing.Color.Black;
            this.Line138.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line138.Border.RightColor = System.Drawing.Color.Black;
            this.Line138.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line138.Border.TopColor = System.Drawing.Color.Black;
            this.Line138.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line138.Height = 0F;
            this.Line138.Left = 0.4375F;
            this.Line138.LineWeight = 1F;
            this.Line138.Name = "Line138";
            this.Line138.Top = 0.1944444F;
            this.Line138.Width = 12.9375F;
            this.Line138.X1 = 0.4375F;
            this.Line138.X2 = 13.375F;
            this.Line138.Y1 = 0.1944444F;
            this.Line138.Y2 = 0.1944444F;
            // 
            // Line139
            // 
            this.Line139.Border.BottomColor = System.Drawing.Color.Black;
            this.Line139.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line139.Border.LeftColor = System.Drawing.Color.Black;
            this.Line139.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line139.Border.RightColor = System.Drawing.Color.Black;
            this.Line139.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line139.Border.TopColor = System.Drawing.Color.Black;
            this.Line139.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line139.Height = 0.1875F;
            this.Line139.Left = 2.694444F;
            this.Line139.LineWeight = 1F;
            this.Line139.Name = "Line139";
            this.Line139.Top = 0.006944358F;
            this.Line139.Width = 0F;
            this.Line139.X1 = 2.694444F;
            this.Line139.X2 = 2.694444F;
            this.Line139.Y1 = 0.006944358F;
            this.Line139.Y2 = 0.1944444F;
            // 
            // Line140
            // 
            this.Line140.Border.BottomColor = System.Drawing.Color.Black;
            this.Line140.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line140.Border.LeftColor = System.Drawing.Color.Black;
            this.Line140.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line140.Border.RightColor = System.Drawing.Color.Black;
            this.Line140.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line140.Border.TopColor = System.Drawing.Color.Black;
            this.Line140.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line140.Height = 0.1875F;
            this.Line140.Left = 3.006944F;
            this.Line140.LineWeight = 1F;
            this.Line140.Name = "Line140";
            this.Line140.Top = 0.006944358F;
            this.Line140.Width = 0F;
            this.Line140.X1 = 3.006944F;
            this.Line140.X2 = 3.006944F;
            this.Line140.Y1 = 0.006944358F;
            this.Line140.Y2 = 0.1944444F;
            // 
            // Line141
            // 
            this.Line141.Border.BottomColor = System.Drawing.Color.Black;
            this.Line141.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line141.Border.LeftColor = System.Drawing.Color.Black;
            this.Line141.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line141.Border.RightColor = System.Drawing.Color.Black;
            this.Line141.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line141.Border.TopColor = System.Drawing.Color.Black;
            this.Line141.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line141.Height = 0.1875F;
            this.Line141.Left = 3.319444F;
            this.Line141.LineWeight = 1F;
            this.Line141.Name = "Line141";
            this.Line141.Top = 0.006944358F;
            this.Line141.Width = 0F;
            this.Line141.X1 = 3.319444F;
            this.Line141.X2 = 3.319444F;
            this.Line141.Y1 = 0.006944358F;
            this.Line141.Y2 = 0.1944444F;
            // 
            // Line142
            // 
            this.Line142.Border.BottomColor = System.Drawing.Color.Black;
            this.Line142.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line142.Border.LeftColor = System.Drawing.Color.Black;
            this.Line142.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line142.Border.RightColor = System.Drawing.Color.Black;
            this.Line142.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line142.Border.TopColor = System.Drawing.Color.Black;
            this.Line142.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line142.Height = 0.1875F;
            this.Line142.Left = 3.631944F;
            this.Line142.LineWeight = 1F;
            this.Line142.Name = "Line142";
            this.Line142.Top = 0.006944358F;
            this.Line142.Width = 0F;
            this.Line142.X1 = 3.631944F;
            this.Line142.X2 = 3.631944F;
            this.Line142.Y1 = 0.006944358F;
            this.Line142.Y2 = 0.1944444F;
            // 
            // Line143
            // 
            this.Line143.Border.BottomColor = System.Drawing.Color.Black;
            this.Line143.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line143.Border.LeftColor = System.Drawing.Color.Black;
            this.Line143.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line143.Border.RightColor = System.Drawing.Color.Black;
            this.Line143.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line143.Border.TopColor = System.Drawing.Color.Black;
            this.Line143.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line143.Height = 0.1875F;
            this.Line143.Left = 3.944444F;
            this.Line143.LineWeight = 1F;
            this.Line143.Name = "Line143";
            this.Line143.Top = 0.006944358F;
            this.Line143.Width = 0F;
            this.Line143.X1 = 3.944444F;
            this.Line143.X2 = 3.944444F;
            this.Line143.Y1 = 0.006944358F;
            this.Line143.Y2 = 0.1944444F;
            // 
            // Line144
            // 
            this.Line144.Border.BottomColor = System.Drawing.Color.Black;
            this.Line144.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line144.Border.LeftColor = System.Drawing.Color.Black;
            this.Line144.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line144.Border.RightColor = System.Drawing.Color.Black;
            this.Line144.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line144.Border.TopColor = System.Drawing.Color.Black;
            this.Line144.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line144.Height = 0.1875F;
            this.Line144.Left = 4.256945F;
            this.Line144.LineWeight = 1F;
            this.Line144.Name = "Line144";
            this.Line144.Top = 0.006944358F;
            this.Line144.Width = 0F;
            this.Line144.X1 = 4.256945F;
            this.Line144.X2 = 4.256945F;
            this.Line144.Y1 = 0.006944358F;
            this.Line144.Y2 = 0.1944444F;
            // 
            // Line145
            // 
            this.Line145.Border.BottomColor = System.Drawing.Color.Black;
            this.Line145.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line145.Border.LeftColor = System.Drawing.Color.Black;
            this.Line145.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line145.Border.RightColor = System.Drawing.Color.Black;
            this.Line145.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line145.Border.TopColor = System.Drawing.Color.Black;
            this.Line145.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line145.Height = 0.1875F;
            this.Line145.Left = 4.569445F;
            this.Line145.LineWeight = 1F;
            this.Line145.Name = "Line145";
            this.Line145.Top = 0.006944358F;
            this.Line145.Width = 0F;
            this.Line145.X1 = 4.569445F;
            this.Line145.X2 = 4.569445F;
            this.Line145.Y1 = 0.006944358F;
            this.Line145.Y2 = 0.1944444F;
            // 
            // Line146
            // 
            this.Line146.Border.BottomColor = System.Drawing.Color.Black;
            this.Line146.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line146.Border.LeftColor = System.Drawing.Color.Black;
            this.Line146.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line146.Border.RightColor = System.Drawing.Color.Black;
            this.Line146.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line146.Border.TopColor = System.Drawing.Color.Black;
            this.Line146.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line146.Height = 0.1875F;
            this.Line146.Left = 4.881945F;
            this.Line146.LineWeight = 1F;
            this.Line146.Name = "Line146";
            this.Line146.Top = 0.006944358F;
            this.Line146.Width = 0F;
            this.Line146.X1 = 4.881945F;
            this.Line146.X2 = 4.881945F;
            this.Line146.Y1 = 0.006944358F;
            this.Line146.Y2 = 0.1944444F;
            // 
            // Line147
            // 
            this.Line147.Border.BottomColor = System.Drawing.Color.Black;
            this.Line147.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line147.Border.LeftColor = System.Drawing.Color.Black;
            this.Line147.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line147.Border.RightColor = System.Drawing.Color.Black;
            this.Line147.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line147.Border.TopColor = System.Drawing.Color.Black;
            this.Line147.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line147.Height = 0.1875F;
            this.Line147.Left = 5.506945F;
            this.Line147.LineWeight = 1F;
            this.Line147.Name = "Line147";
            this.Line147.Top = 0.006944358F;
            this.Line147.Width = 0F;
            this.Line147.X1 = 5.506945F;
            this.Line147.X2 = 5.506945F;
            this.Line147.Y1 = 0.006944358F;
            this.Line147.Y2 = 0.1944444F;
            // 
            // Line148
            // 
            this.Line148.Border.BottomColor = System.Drawing.Color.Black;
            this.Line148.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line148.Border.LeftColor = System.Drawing.Color.Black;
            this.Line148.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line148.Border.RightColor = System.Drawing.Color.Black;
            this.Line148.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line148.Border.TopColor = System.Drawing.Color.Black;
            this.Line148.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line148.Height = 0.1875F;
            this.Line148.Left = 5.194445F;
            this.Line148.LineWeight = 1F;
            this.Line148.Name = "Line148";
            this.Line148.Top = 0.006944358F;
            this.Line148.Width = 0F;
            this.Line148.X1 = 5.194445F;
            this.Line148.X2 = 5.194445F;
            this.Line148.Y1 = 0.006944358F;
            this.Line148.Y2 = 0.1944444F;
            // 
            // Line149
            // 
            this.Line149.Border.BottomColor = System.Drawing.Color.Black;
            this.Line149.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line149.Border.LeftColor = System.Drawing.Color.Black;
            this.Line149.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line149.Border.RightColor = System.Drawing.Color.Black;
            this.Line149.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line149.Border.TopColor = System.Drawing.Color.Black;
            this.Line149.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line149.Height = 0.1875F;
            this.Line149.Left = 5.819445F;
            this.Line149.LineWeight = 1F;
            this.Line149.Name = "Line149";
            this.Line149.Top = 0.006944358F;
            this.Line149.Width = 0F;
            this.Line149.X1 = 5.819445F;
            this.Line149.X2 = 5.819445F;
            this.Line149.Y1 = 0.006944358F;
            this.Line149.Y2 = 0.1944444F;
            // 
            // Line150
            // 
            this.Line150.Border.BottomColor = System.Drawing.Color.Black;
            this.Line150.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line150.Border.LeftColor = System.Drawing.Color.Black;
            this.Line150.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line150.Border.RightColor = System.Drawing.Color.Black;
            this.Line150.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line150.Border.TopColor = System.Drawing.Color.Black;
            this.Line150.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line150.Height = 0.1875F;
            this.Line150.Left = 6.131945F;
            this.Line150.LineWeight = 1F;
            this.Line150.Name = "Line150";
            this.Line150.Top = 0.006944358F;
            this.Line150.Width = 0F;
            this.Line150.X1 = 6.131945F;
            this.Line150.X2 = 6.131945F;
            this.Line150.Y1 = 0.006944358F;
            this.Line150.Y2 = 0.1944444F;
            // 
            // Line151
            // 
            this.Line151.Border.BottomColor = System.Drawing.Color.Black;
            this.Line151.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line151.Border.LeftColor = System.Drawing.Color.Black;
            this.Line151.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line151.Border.RightColor = System.Drawing.Color.Black;
            this.Line151.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line151.Border.TopColor = System.Drawing.Color.Black;
            this.Line151.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line151.Height = 0.1875F;
            this.Line151.Left = 6.444445F;
            this.Line151.LineWeight = 1F;
            this.Line151.Name = "Line151";
            this.Line151.Top = 0.006944358F;
            this.Line151.Width = 0F;
            this.Line151.X1 = 6.444445F;
            this.Line151.X2 = 6.444445F;
            this.Line151.Y1 = 0.006944358F;
            this.Line151.Y2 = 0.1944444F;
            // 
            // Line152
            // 
            this.Line152.Border.BottomColor = System.Drawing.Color.Black;
            this.Line152.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line152.Border.LeftColor = System.Drawing.Color.Black;
            this.Line152.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line152.Border.RightColor = System.Drawing.Color.Black;
            this.Line152.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line152.Border.TopColor = System.Drawing.Color.Black;
            this.Line152.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line152.Height = 0.1875F;
            this.Line152.Left = 6.756945F;
            this.Line152.LineWeight = 1F;
            this.Line152.Name = "Line152";
            this.Line152.Top = 0.006944358F;
            this.Line152.Width = 0F;
            this.Line152.X1 = 6.756945F;
            this.Line152.X2 = 6.756945F;
            this.Line152.Y1 = 0.006944358F;
            this.Line152.Y2 = 0.1944444F;
            // 
            // Line153
            // 
            this.Line153.Border.BottomColor = System.Drawing.Color.Black;
            this.Line153.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line153.Border.LeftColor = System.Drawing.Color.Black;
            this.Line153.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line153.Border.RightColor = System.Drawing.Color.Black;
            this.Line153.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line153.Border.TopColor = System.Drawing.Color.Black;
            this.Line153.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line153.Height = 0.1875F;
            this.Line153.Left = 7.069445F;
            this.Line153.LineWeight = 1F;
            this.Line153.Name = "Line153";
            this.Line153.Top = 0.006944358F;
            this.Line153.Width = 0F;
            this.Line153.X1 = 7.069445F;
            this.Line153.X2 = 7.069445F;
            this.Line153.Y1 = 0.006944358F;
            this.Line153.Y2 = 0.1944444F;
            // 
            // Line154
            // 
            this.Line154.Border.BottomColor = System.Drawing.Color.Black;
            this.Line154.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line154.Border.LeftColor = System.Drawing.Color.Black;
            this.Line154.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line154.Border.RightColor = System.Drawing.Color.Black;
            this.Line154.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line154.Border.TopColor = System.Drawing.Color.Black;
            this.Line154.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line154.Height = 0.1875F;
            this.Line154.Left = 7.381945F;
            this.Line154.LineWeight = 1F;
            this.Line154.Name = "Line154";
            this.Line154.Top = 0.006944358F;
            this.Line154.Width = 0F;
            this.Line154.X1 = 7.381945F;
            this.Line154.X2 = 7.381945F;
            this.Line154.Y1 = 0.006944358F;
            this.Line154.Y2 = 0.1944444F;
            // 
            // Line155
            // 
            this.Line155.Border.BottomColor = System.Drawing.Color.Black;
            this.Line155.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line155.Border.LeftColor = System.Drawing.Color.Black;
            this.Line155.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line155.Border.RightColor = System.Drawing.Color.Black;
            this.Line155.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line155.Border.TopColor = System.Drawing.Color.Black;
            this.Line155.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line155.Height = 0.1875F;
            this.Line155.Left = 7.694445F;
            this.Line155.LineWeight = 1F;
            this.Line155.Name = "Line155";
            this.Line155.Top = 0.006944358F;
            this.Line155.Width = 0F;
            this.Line155.X1 = 7.694445F;
            this.Line155.X2 = 7.694445F;
            this.Line155.Y1 = 0.006944358F;
            this.Line155.Y2 = 0.1944444F;
            // 
            // Line156
            // 
            this.Line156.Border.BottomColor = System.Drawing.Color.Black;
            this.Line156.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line156.Border.LeftColor = System.Drawing.Color.Black;
            this.Line156.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line156.Border.RightColor = System.Drawing.Color.Black;
            this.Line156.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line156.Border.TopColor = System.Drawing.Color.Black;
            this.Line156.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line156.Height = 0.1875F;
            this.Line156.Left = 8.006945F;
            this.Line156.LineWeight = 1F;
            this.Line156.Name = "Line156";
            this.Line156.Top = 0.006944358F;
            this.Line156.Width = 0F;
            this.Line156.X1 = 8.006945F;
            this.Line156.X2 = 8.006945F;
            this.Line156.Y1 = 0.006944358F;
            this.Line156.Y2 = 0.1944444F;
            // 
            // Line157
            // 
            this.Line157.Border.BottomColor = System.Drawing.Color.Black;
            this.Line157.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line157.Border.LeftColor = System.Drawing.Color.Black;
            this.Line157.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line157.Border.RightColor = System.Drawing.Color.Black;
            this.Line157.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line157.Border.TopColor = System.Drawing.Color.Black;
            this.Line157.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line157.Height = 0.1875F;
            this.Line157.Left = 8.319445F;
            this.Line157.LineWeight = 1F;
            this.Line157.Name = "Line157";
            this.Line157.Top = 0.006944358F;
            this.Line157.Width = 0F;
            this.Line157.X1 = 8.319445F;
            this.Line157.X2 = 8.319445F;
            this.Line157.Y1 = 0.006944358F;
            this.Line157.Y2 = 0.1944444F;
            // 
            // Line158
            // 
            this.Line158.Border.BottomColor = System.Drawing.Color.Black;
            this.Line158.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line158.Border.LeftColor = System.Drawing.Color.Black;
            this.Line158.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line158.Border.RightColor = System.Drawing.Color.Black;
            this.Line158.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line158.Border.TopColor = System.Drawing.Color.Black;
            this.Line158.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line158.Height = 0.1875F;
            this.Line158.Left = 8.631945F;
            this.Line158.LineWeight = 1F;
            this.Line158.Name = "Line158";
            this.Line158.Top = 0.006944358F;
            this.Line158.Width = 0F;
            this.Line158.X1 = 8.631945F;
            this.Line158.X2 = 8.631945F;
            this.Line158.Y1 = 0.006944358F;
            this.Line158.Y2 = 0.1944444F;
            // 
            // Line159
            // 
            this.Line159.Border.BottomColor = System.Drawing.Color.Black;
            this.Line159.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line159.Border.LeftColor = System.Drawing.Color.Black;
            this.Line159.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line159.Border.RightColor = System.Drawing.Color.Black;
            this.Line159.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line159.Border.TopColor = System.Drawing.Color.Black;
            this.Line159.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line159.Height = 0.1875F;
            this.Line159.Left = 8.944445F;
            this.Line159.LineWeight = 1F;
            this.Line159.Name = "Line159";
            this.Line159.Top = 0.006944358F;
            this.Line159.Width = 0F;
            this.Line159.X1 = 8.944445F;
            this.Line159.X2 = 8.944445F;
            this.Line159.Y1 = 0.006944358F;
            this.Line159.Y2 = 0.1944444F;
            // 
            // Line160
            // 
            this.Line160.Border.BottomColor = System.Drawing.Color.Black;
            this.Line160.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line160.Border.LeftColor = System.Drawing.Color.Black;
            this.Line160.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line160.Border.RightColor = System.Drawing.Color.Black;
            this.Line160.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line160.Border.TopColor = System.Drawing.Color.Black;
            this.Line160.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line160.Height = 0.1875F;
            this.Line160.Left = 9.256945F;
            this.Line160.LineWeight = 1F;
            this.Line160.Name = "Line160";
            this.Line160.Top = 0.006944358F;
            this.Line160.Width = 0F;
            this.Line160.X1 = 9.256945F;
            this.Line160.X2 = 9.256945F;
            this.Line160.Y1 = 0.006944358F;
            this.Line160.Y2 = 0.1944444F;
            // 
            // Line161
            // 
            this.Line161.Border.BottomColor = System.Drawing.Color.Black;
            this.Line161.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line161.Border.LeftColor = System.Drawing.Color.Black;
            this.Line161.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line161.Border.RightColor = System.Drawing.Color.Black;
            this.Line161.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line161.Border.TopColor = System.Drawing.Color.Black;
            this.Line161.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line161.Height = 0.1875F;
            this.Line161.Left = 9.569445F;
            this.Line161.LineWeight = 1F;
            this.Line161.Name = "Line161";
            this.Line161.Top = 0.006944358F;
            this.Line161.Width = 0F;
            this.Line161.X1 = 9.569445F;
            this.Line161.X2 = 9.569445F;
            this.Line161.Y1 = 0.006944358F;
            this.Line161.Y2 = 0.1944444F;
            // 
            // Line162
            // 
            this.Line162.Border.BottomColor = System.Drawing.Color.Black;
            this.Line162.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line162.Border.LeftColor = System.Drawing.Color.Black;
            this.Line162.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line162.Border.RightColor = System.Drawing.Color.Black;
            this.Line162.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line162.Border.TopColor = System.Drawing.Color.Black;
            this.Line162.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line162.Height = 0.1875F;
            this.Line162.Left = 9.881945F;
            this.Line162.LineWeight = 1F;
            this.Line162.Name = "Line162";
            this.Line162.Top = 0.006944358F;
            this.Line162.Width = 0F;
            this.Line162.X1 = 9.881945F;
            this.Line162.X2 = 9.881945F;
            this.Line162.Y1 = 0.006944358F;
            this.Line162.Y2 = 0.1944444F;
            // 
            // Line163
            // 
            this.Line163.Border.BottomColor = System.Drawing.Color.Black;
            this.Line163.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line163.Border.LeftColor = System.Drawing.Color.Black;
            this.Line163.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line163.Border.RightColor = System.Drawing.Color.Black;
            this.Line163.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line163.Border.TopColor = System.Drawing.Color.Black;
            this.Line163.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line163.Height = 0.1875F;
            this.Line163.Left = 10.19444F;
            this.Line163.LineWeight = 1F;
            this.Line163.Name = "Line163";
            this.Line163.Top = 0.006944358F;
            this.Line163.Width = 0F;
            this.Line163.X1 = 10.19444F;
            this.Line163.X2 = 10.19444F;
            this.Line163.Y1 = 0.006944358F;
            this.Line163.Y2 = 0.1944444F;
            // 
            // Line164
            // 
            this.Line164.Border.BottomColor = System.Drawing.Color.Black;
            this.Line164.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line164.Border.LeftColor = System.Drawing.Color.Black;
            this.Line164.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line164.Border.RightColor = System.Drawing.Color.Black;
            this.Line164.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line164.Border.TopColor = System.Drawing.Color.Black;
            this.Line164.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line164.Height = 0.1875F;
            this.Line164.Left = 10.50694F;
            this.Line164.LineWeight = 1F;
            this.Line164.Name = "Line164";
            this.Line164.Top = 0.006944358F;
            this.Line164.Width = 0F;
            this.Line164.X1 = 10.50694F;
            this.Line164.X2 = 10.50694F;
            this.Line164.Y1 = 0.006944358F;
            this.Line164.Y2 = 0.1944444F;
            // 
            // Line165
            // 
            this.Line165.Border.BottomColor = System.Drawing.Color.Black;
            this.Line165.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line165.Border.LeftColor = System.Drawing.Color.Black;
            this.Line165.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line165.Border.RightColor = System.Drawing.Color.Black;
            this.Line165.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line165.Border.TopColor = System.Drawing.Color.Black;
            this.Line165.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line165.Height = 0.1875F;
            this.Line165.Left = 11.13194F;
            this.Line165.LineWeight = 1F;
            this.Line165.Name = "Line165";
            this.Line165.Top = 0.006944358F;
            this.Line165.Width = 0F;
            this.Line165.X1 = 11.13194F;
            this.Line165.X2 = 11.13194F;
            this.Line165.Y1 = 0.006944358F;
            this.Line165.Y2 = 0.1944444F;
            // 
            // Line166
            // 
            this.Line166.Border.BottomColor = System.Drawing.Color.Black;
            this.Line166.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line166.Border.LeftColor = System.Drawing.Color.Black;
            this.Line166.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line166.Border.RightColor = System.Drawing.Color.Black;
            this.Line166.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line166.Border.TopColor = System.Drawing.Color.Black;
            this.Line166.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line166.Height = 0.1875F;
            this.Line166.Left = 12.75694F;
            this.Line166.LineWeight = 1F;
            this.Line166.Name = "Line166";
            this.Line166.Top = 0.006944358F;
            this.Line166.Width = 0F;
            this.Line166.X1 = 12.75694F;
            this.Line166.X2 = 12.75694F;
            this.Line166.Y1 = 0.006944358F;
            this.Line166.Y2 = 0.1944444F;
            // 
            // Line167
            // 
            this.Line167.Border.BottomColor = System.Drawing.Color.Black;
            this.Line167.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line167.Border.LeftColor = System.Drawing.Color.Black;
            this.Line167.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line167.Border.RightColor = System.Drawing.Color.Black;
            this.Line167.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line167.Border.TopColor = System.Drawing.Color.Black;
            this.Line167.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line167.Height = 0.1875F;
            this.Line167.Left = 12.06944F;
            this.Line167.LineWeight = 1F;
            this.Line167.Name = "Line167";
            this.Line167.Top = 0.006944358F;
            this.Line167.Width = 0F;
            this.Line167.X1 = 12.06944F;
            this.Line167.X2 = 12.06944F;
            this.Line167.Y1 = 0.006944358F;
            this.Line167.Y2 = 0.1944444F;
            // 
            // Line168
            // 
            this.Line168.Border.BottomColor = System.Drawing.Color.Black;
            this.Line168.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line168.Border.LeftColor = System.Drawing.Color.Black;
            this.Line168.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line168.Border.RightColor = System.Drawing.Color.Black;
            this.Line168.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line168.Border.TopColor = System.Drawing.Color.Black;
            this.Line168.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line168.Height = 0.1875F;
            this.Line168.Left = 11.75694F;
            this.Line168.LineWeight = 1F;
            this.Line168.Name = "Line168";
            this.Line168.Top = 0.006944358F;
            this.Line168.Width = 0F;
            this.Line168.X1 = 11.75694F;
            this.Line168.X2 = 11.75694F;
            this.Line168.Y1 = 0.006944358F;
            this.Line168.Y2 = 0.1944444F;
            // 
            // Line169
            // 
            this.Line169.Border.BottomColor = System.Drawing.Color.Black;
            this.Line169.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line169.Border.LeftColor = System.Drawing.Color.Black;
            this.Line169.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line169.Border.RightColor = System.Drawing.Color.Black;
            this.Line169.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line169.Border.TopColor = System.Drawing.Color.Black;
            this.Line169.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line169.Height = 0.1875F;
            this.Line169.Left = 11.44444F;
            this.Line169.LineWeight = 1F;
            this.Line169.Name = "Line169";
            this.Line169.Top = 0.006944358F;
            this.Line169.Width = 0F;
            this.Line169.X1 = 11.44444F;
            this.Line169.X2 = 11.44444F;
            this.Line169.Y1 = 0.006944358F;
            this.Line169.Y2 = 0.1944444F;
            // 
            // Line170
            // 
            this.Line170.Border.BottomColor = System.Drawing.Color.Black;
            this.Line170.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line170.Border.LeftColor = System.Drawing.Color.Black;
            this.Line170.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line170.Border.RightColor = System.Drawing.Color.Black;
            this.Line170.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line170.Border.TopColor = System.Drawing.Color.Black;
            this.Line170.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line170.Height = 0.1875F;
            this.Line170.Left = 10.81944F;
            this.Line170.LineWeight = 1F;
            this.Line170.Name = "Line170";
            this.Line170.Top = 0.006944358F;
            this.Line170.Width = 0F;
            this.Line170.X1 = 10.81944F;
            this.Line170.X2 = 10.81944F;
            this.Line170.Y1 = 0.006944358F;
            this.Line170.Y2 = 0.1944444F;
            // 
            // Line171
            // 
            this.Line171.Border.BottomColor = System.Drawing.Color.Black;
            this.Line171.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line171.Border.LeftColor = System.Drawing.Color.Black;
            this.Line171.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line171.Border.RightColor = System.Drawing.Color.Black;
            this.Line171.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line171.Border.TopColor = System.Drawing.Color.Black;
            this.Line171.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line171.Height = 0.1875F;
            this.Line171.Left = 2.381944F;
            this.Line171.LineWeight = 1F;
            this.Line171.Name = "Line171";
            this.Line171.Top = 0.006944358F;
            this.Line171.Width = 0F;
            this.Line171.X1 = 2.381944F;
            this.Line171.X2 = 2.381944F;
            this.Line171.Y1 = 0.006944358F;
            this.Line171.Y2 = 0.1944444F;
            // 
            // TextBox65
            // 
            this.TextBox65.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox65.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox65.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox65.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox65.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox65.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox65.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox65.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox65.DataField = "DIA_1";
            this.TextBox65.Height = 0.2F;
            this.TextBox65.Left = 2.4375F;
            this.TextBox65.Name = "TextBox65";
            this.TextBox65.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox65.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox65.Text = null;
            this.TextBox65.Top = 0F;
            this.TextBox65.Width = 0.25F;
            // 
            // TextBox66
            // 
            this.TextBox66.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox66.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox66.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox66.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox66.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox66.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox66.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox66.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox66.DataField = "DIA_2";
            this.TextBox66.Height = 0.2F;
            this.TextBox66.Left = 2.75F;
            this.TextBox66.Name = "TextBox66";
            this.TextBox66.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox66.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox66.Text = null;
            this.TextBox66.Top = 0F;
            this.TextBox66.Width = 0.25F;
            // 
            // TextBox67
            // 
            this.TextBox67.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox67.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox67.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox67.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox67.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox67.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox67.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox67.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox67.DataField = "DIA_3";
            this.TextBox67.Height = 0.2F;
            this.TextBox67.Left = 3.0625F;
            this.TextBox67.Name = "TextBox67";
            this.TextBox67.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox67.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox67.Text = null;
            this.TextBox67.Top = 0F;
            this.TextBox67.Width = 0.25F;
            // 
            // TextBox68
            // 
            this.TextBox68.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox68.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox68.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox68.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox68.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox68.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox68.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox68.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox68.DataField = "DIA_4";
            this.TextBox68.Height = 0.2F;
            this.TextBox68.Left = 3.375F;
            this.TextBox68.Name = "TextBox68";
            this.TextBox68.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox68.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox68.Text = null;
            this.TextBox68.Top = 0F;
            this.TextBox68.Width = 0.25F;
            // 
            // TextBox69
            // 
            this.TextBox69.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox69.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox69.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox69.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox69.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox69.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox69.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox69.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox69.DataField = "DIA_5";
            this.TextBox69.Height = 0.2F;
            this.TextBox69.Left = 3.625F;
            this.TextBox69.Name = "TextBox69";
            this.TextBox69.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox69.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox69.Text = null;
            this.TextBox69.Top = 0F;
            this.TextBox69.Width = 0.25F;
            // 
            // TextBox70
            // 
            this.TextBox70.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox70.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox70.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox70.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox70.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox70.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox70.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox70.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox70.DataField = "DIA_6";
            this.TextBox70.Height = 0.2F;
            this.TextBox70.Left = 4F;
            this.TextBox70.Name = "TextBox70";
            this.TextBox70.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox70.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox70.Text = null;
            this.TextBox70.Top = 0F;
            this.TextBox70.Width = 0.25F;
            // 
            // TextBox71
            // 
            this.TextBox71.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox71.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox71.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox71.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox71.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox71.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox71.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox71.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox71.DataField = "DIA_7";
            this.TextBox71.Height = 0.2F;
            this.TextBox71.Left = 4.3125F;
            this.TextBox71.Name = "TextBox71";
            this.TextBox71.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox71.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox71.Text = null;
            this.TextBox71.Top = 0F;
            this.TextBox71.Width = 0.25F;
            // 
            // TextBox72
            // 
            this.TextBox72.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox72.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox72.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox72.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox72.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox72.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox72.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox72.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox72.DataField = "DIA_8";
            this.TextBox72.Height = 0.2F;
            this.TextBox72.Left = 4.625F;
            this.TextBox72.Name = "TextBox72";
            this.TextBox72.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox72.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox72.Text = null;
            this.TextBox72.Top = 0F;
            this.TextBox72.Width = 0.25F;
            // 
            // TextBox73
            // 
            this.TextBox73.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox73.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox73.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox73.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox73.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox73.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox73.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox73.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox73.DataField = "DIA_9";
            this.TextBox73.Height = 0.2F;
            this.TextBox73.Left = 4.9375F;
            this.TextBox73.Name = "TextBox73";
            this.TextBox73.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox73.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox73.Text = null;
            this.TextBox73.Top = 0F;
            this.TextBox73.Width = 0.25F;
            // 
            // TextBox74
            // 
            this.TextBox74.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox74.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox74.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox74.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox74.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox74.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox74.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox74.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox74.DataField = "DIA_10";
            this.TextBox74.Height = 0.2F;
            this.TextBox74.Left = 5.25F;
            this.TextBox74.Name = "TextBox74";
            this.TextBox74.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox74.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox74.Text = null;
            this.TextBox74.Top = 0F;
            this.TextBox74.Width = 0.25F;
            // 
            // TextBox75
            // 
            this.TextBox75.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox75.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox75.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox75.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox75.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox75.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox75.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox75.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox75.DataField = "DIA_11";
            this.TextBox75.Height = 0.2F;
            this.TextBox75.Left = 5.5625F;
            this.TextBox75.Name = "TextBox75";
            this.TextBox75.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox75.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox75.Text = null;
            this.TextBox75.Top = 0F;
            this.TextBox75.Width = 0.25F;
            // 
            // TextBox76
            // 
            this.TextBox76.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox76.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox76.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox76.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox76.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox76.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox76.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox76.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox76.DataField = "DIA_12";
            this.TextBox76.Height = 0.2F;
            this.TextBox76.Left = 5.875F;
            this.TextBox76.Name = "TextBox76";
            this.TextBox76.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox76.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox76.Text = null;
            this.TextBox76.Top = 0F;
            this.TextBox76.Width = 0.25F;
            // 
            // TextBox77
            // 
            this.TextBox77.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox77.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox77.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox77.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox77.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox77.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox77.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox77.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox77.DataField = "DIA_13";
            this.TextBox77.Height = 0.2F;
            this.TextBox77.Left = 6.1875F;
            this.TextBox77.Name = "TextBox77";
            this.TextBox77.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox77.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox77.Text = null;
            this.TextBox77.Top = 0F;
            this.TextBox77.Width = 0.25F;
            // 
            // TextBox78
            // 
            this.TextBox78.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox78.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox78.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox78.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox78.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox78.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox78.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox78.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox78.DataField = "DIA_14";
            this.TextBox78.Height = 0.2F;
            this.TextBox78.Left = 6.5F;
            this.TextBox78.Name = "TextBox78";
            this.TextBox78.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox78.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox78.Text = null;
            this.TextBox78.Top = 0F;
            this.TextBox78.Width = 0.25F;
            // 
            // TextBox79
            // 
            this.TextBox79.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox79.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox79.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox79.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox79.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox79.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox79.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox79.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox79.DataField = "DIA_15";
            this.TextBox79.Height = 0.2F;
            this.TextBox79.Left = 6.8125F;
            this.TextBox79.Name = "TextBox79";
            this.TextBox79.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox79.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox79.Text = null;
            this.TextBox79.Top = 0F;
            this.TextBox79.Width = 0.25F;
            // 
            // TextBox80
            // 
            this.TextBox80.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox80.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox80.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox80.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox80.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox80.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox80.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox80.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox80.DataField = "DIA_16";
            this.TextBox80.Height = 0.2F;
            this.TextBox80.Left = 7.125F;
            this.TextBox80.Name = "TextBox80";
            this.TextBox80.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox80.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox80.Text = null;
            this.TextBox80.Top = 0F;
            this.TextBox80.Width = 0.25F;
            // 
            // TextBox81
            // 
            this.TextBox81.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox81.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox81.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox81.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox81.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox81.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox81.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox81.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox81.DataField = "DIA_17";
            this.TextBox81.Height = 0.2F;
            this.TextBox81.Left = 7.4375F;
            this.TextBox81.Name = "TextBox81";
            this.TextBox81.Style = "text-align: center; font-size: 7pt; vertical-align: top; ";
            this.TextBox81.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox81.Text = null;
            this.TextBox81.Top = 0F;
            this.TextBox81.Width = 0.25F;
            // 
            // TextBox82
            // 
            this.TextBox82.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox82.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox82.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox82.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox82.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox82.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox82.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox82.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox82.DataField = "DIA_18";
            this.TextBox82.Height = 0.2F;
            this.TextBox82.Left = 7.75F;
            this.TextBox82.Name = "TextBox82";
            this.TextBox82.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox82.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox82.Text = null;
            this.TextBox82.Top = 0F;
            this.TextBox82.Width = 0.25F;
            // 
            // TextBox83
            // 
            this.TextBox83.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox83.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox83.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox83.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox83.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox83.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox83.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox83.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox83.DataField = "DIA_19";
            this.TextBox83.Height = 0.2F;
            this.TextBox83.Left = 8.0625F;
            this.TextBox83.Name = "TextBox83";
            this.TextBox83.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox83.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox83.Text = null;
            this.TextBox83.Top = 0F;
            this.TextBox83.Width = 0.25F;
            // 
            // TextBox84
            // 
            this.TextBox84.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox84.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox84.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox84.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox84.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox84.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox84.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox84.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox84.DataField = "DIA_20";
            this.TextBox84.Height = 0.2F;
            this.TextBox84.Left = 8.375F;
            this.TextBox84.Name = "TextBox84";
            this.TextBox84.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox84.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox84.Text = null;
            this.TextBox84.Top = 0F;
            this.TextBox84.Width = 0.25F;
            // 
            // TextBox85
            // 
            this.TextBox85.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox85.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox85.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox85.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox85.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox85.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox85.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox85.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox85.DataField = "DIA_21";
            this.TextBox85.Height = 0.2F;
            this.TextBox85.Left = 8.6875F;
            this.TextBox85.Name = "TextBox85";
            this.TextBox85.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox85.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox85.Text = null;
            this.TextBox85.Top = 0F;
            this.TextBox85.Width = 0.25F;
            // 
            // TextBox86
            // 
            this.TextBox86.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox86.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox86.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox86.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox86.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox86.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox86.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox86.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox86.DataField = "DIA_22";
            this.TextBox86.Height = 0.2F;
            this.TextBox86.Left = 9F;
            this.TextBox86.Name = "TextBox86";
            this.TextBox86.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox86.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox86.Text = null;
            this.TextBox86.Top = 0F;
            this.TextBox86.Width = 0.25F;
            // 
            // TextBox87
            // 
            this.TextBox87.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox87.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox87.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox87.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox87.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox87.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox87.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox87.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox87.DataField = "DIA_23";
            this.TextBox87.Height = 0.2F;
            this.TextBox87.Left = 9.3125F;
            this.TextBox87.Name = "TextBox87";
            this.TextBox87.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox87.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox87.Text = null;
            this.TextBox87.Top = 0F;
            this.TextBox87.Width = 0.25F;
            // 
            // TextBox88
            // 
            this.TextBox88.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox88.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox88.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox88.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox88.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox88.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox88.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox88.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox88.DataField = "DIA_24";
            this.TextBox88.Height = 0.2F;
            this.TextBox88.Left = 9.625F;
            this.TextBox88.Name = "TextBox88";
            this.TextBox88.Style = "text-align: center; font-size: 7pt; vertical-align: top; ";
            this.TextBox88.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox88.Text = null;
            this.TextBox88.Top = 0F;
            this.TextBox88.Width = 0.25F;
            // 
            // TextBox89
            // 
            this.TextBox89.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox89.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox89.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox89.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox89.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox89.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox89.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox89.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox89.DataField = "DIA_25";
            this.TextBox89.Height = 0.2F;
            this.TextBox89.Left = 9.9375F;
            this.TextBox89.Name = "TextBox89";
            this.TextBox89.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox89.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox89.Text = null;
            this.TextBox89.Top = 0F;
            this.TextBox89.Width = 0.25F;
            // 
            // TextBox90
            // 
            this.TextBox90.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox90.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox90.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox90.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox90.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox90.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox90.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox90.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox90.DataField = "DIA_26";
            this.TextBox90.Height = 0.2F;
            this.TextBox90.Left = 10.25F;
            this.TextBox90.Name = "TextBox90";
            this.TextBox90.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox90.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox90.Text = null;
            this.TextBox90.Top = 0F;
            this.TextBox90.Width = 0.25F;
            // 
            // TextBox91
            // 
            this.TextBox91.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox91.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox91.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox91.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox91.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox91.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox91.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox91.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox91.DataField = "DIA_27";
            this.TextBox91.Height = 0.2F;
            this.TextBox91.Left = 10.5625F;
            this.TextBox91.Name = "TextBox91";
            this.TextBox91.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox91.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox91.Text = null;
            this.TextBox91.Top = 0F;
            this.TextBox91.Width = 0.25F;
            // 
            // TextBox92
            // 
            this.TextBox92.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox92.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox92.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox92.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox92.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox92.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox92.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox92.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox92.DataField = "DIA_28";
            this.TextBox92.Height = 0.2F;
            this.TextBox92.Left = 10.875F;
            this.TextBox92.Name = "TextBox92";
            this.TextBox92.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox92.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox92.Text = null;
            this.TextBox92.Top = 0F;
            this.TextBox92.Width = 0.25F;
            // 
            // TextBox93
            // 
            this.TextBox93.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox93.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox93.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox93.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox93.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox93.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox93.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox93.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox93.DataField = "DIA_29";
            this.TextBox93.Height = 0.2F;
            this.TextBox93.Left = 11.1875F;
            this.TextBox93.Name = "TextBox93";
            this.TextBox93.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox93.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox93.Text = null;
            this.TextBox93.Top = 0F;
            this.TextBox93.Width = 0.25F;
            // 
            // TextBox94
            // 
            this.TextBox94.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox94.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox94.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox94.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox94.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox94.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox94.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox94.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox94.DataField = "DIA_30";
            this.TextBox94.Height = 0.2F;
            this.TextBox94.Left = 11.5F;
            this.TextBox94.Name = "TextBox94";
            this.TextBox94.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox94.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox94.Text = null;
            this.TextBox94.Top = 0F;
            this.TextBox94.Width = 0.25F;
            // 
            // TextBox95
            // 
            this.TextBox95.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox95.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox95.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox95.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox95.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox95.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox95.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox95.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox95.DataField = "DIA_31";
            this.TextBox95.Height = 0.2F;
            this.TextBox95.Left = 11.8125F;
            this.TextBox95.Name = "TextBox95";
            this.TextBox95.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox95.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox95.Text = null;
            this.TextBox95.Top = 0F;
            this.TextBox95.Width = 0.25F;
            // 
            // TextBox96
            // 
            this.TextBox96.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox96.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox96.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox96.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox96.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox96.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox96.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox96.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox96.DataField = "Total_cantidad";
            this.TextBox96.Height = 0.2F;
            this.TextBox96.Left = 12.125F;
            this.TextBox96.Name = "TextBox96";
            this.TextBox96.OutputFormat = resources.GetString("TextBox96.OutputFormat");
            this.TextBox96.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox96.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox96.Text = null;
            this.TextBox96.Top = 0F;
            this.TextBox96.Width = 0.625F;
            // 
            // TextBox97
            // 
            this.TextBox97.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox97.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox97.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox97.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox97.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox97.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox97.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox97.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox97.DataField = "Mes_Anterior";
            this.TextBox97.Height = 0.2F;
            this.TextBox97.Left = 12.75F;
            this.TextBox97.Name = "TextBox97";
            this.TextBox97.OutputFormat = resources.GetString("TextBox97.OutputFormat");
            this.TextBox97.Style = "text-align: center; font-size: 7pt; ";
            this.TextBox97.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox97.Text = null;
            this.TextBox97.Top = 0F;
            this.TextBox97.Width = 0.5625F;
            // 
            // Line172
            // 
            this.Line172.Border.BottomColor = System.Drawing.Color.Black;
            this.Line172.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line172.Border.LeftColor = System.Drawing.Color.Black;
            this.Line172.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line172.Border.RightColor = System.Drawing.Color.Black;
            this.Line172.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line172.Border.TopColor = System.Drawing.Color.Black;
            this.Line172.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line172.Height = 0.1875F;
            this.Line172.Left = 13.375F;
            this.Line172.LineWeight = 1F;
            this.Line172.Name = "Line172";
            this.Line172.Top = 0.006944444F;
            this.Line172.Width = 0F;
            this.Line172.X1 = 13.375F;
            this.Line172.X2 = 13.375F;
            this.Line172.Y1 = 0.006944444F;
            this.Line172.Y2 = 0.1944444F;
            // 
            // Label234
            // 
            this.Label234.Border.BottomColor = System.Drawing.Color.Black;
            this.Label234.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label234.Border.LeftColor = System.Drawing.Color.Black;
            this.Label234.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label234.Border.RightColor = System.Drawing.Color.Black;
            this.Label234.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label234.Border.TopColor = System.Drawing.Color.Black;
            this.Label234.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label234.Height = 0.2F;
            this.Label234.HyperLink = "";
            this.Label234.Left = 0.5F;
            this.Label234.Name = "Label234";
            this.Label234.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label234.Text = "Totals:";
            this.Label234.Top = 0F;
            this.Label234.Width = 1F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Shape3,
            this.Label200,
            this.Label201,
            this.Label202,
            this.Label203,
            this.Label204,
            this.Label205,
            this.Label206,
            this.Label207,
            this.Label208,
            this.Label209,
            this.Label210,
            this.Label211,
            this.Label212,
            this.Label213,
            this.Label214,
            this.Label215,
            this.Label216,
            this.Label217,
            this.Label218,
            this.Label219,
            this.Label220,
            this.Label221,
            this.Label222,
            this.Label223,
            this.Label224,
            this.Label225,
            this.Label226,
            this.Label227,
            this.Label228,
            this.Label229,
            this.Label230,
            this.Label231,
            this.Label232,
            this.Line103,
            this.Line104,
            this.Line105,
            this.Line106,
            this.Line107,
            this.Line108,
            this.Line109,
            this.Line110,
            this.Line111,
            this.Line112,
            this.Line113,
            this.Line114,
            this.Line115,
            this.Line116,
            this.Line117,
            this.Line118,
            this.Line119,
            this.Line120,
            this.Line121,
            this.Line122,
            this.Line123,
            this.Line124,
            this.Line125,
            this.Line126,
            this.Line127,
            this.Line128,
            this.Line129,
            this.Line130,
            this.Line131,
            this.Line132,
            this.Line133,
            this.Line134,
            this.Line135,
            this.Label233,
            this.Label235});
            this.PageHeader.Height = 0.2F;
            this.PageHeader.Name = "PageHeader";
            // 
            // Shape3
            // 
            this.Shape3.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.RightColor = System.Drawing.Color.Black;
            this.Shape3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.TopColor = System.Drawing.Color.Black;
            this.Shape3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Height = 0.1875F;
            this.Shape3.Left = 0.4375F;
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = 9.999999F;
            this.Shape3.Top = 5.960464E-08F;
            this.Shape3.Width = 12.9375F;
            // 
            // Label200
            // 
            this.Label200.Border.BottomColor = System.Drawing.Color.Black;
            this.Label200.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label200.Border.LeftColor = System.Drawing.Color.Black;
            this.Label200.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label200.Border.RightColor = System.Drawing.Color.Black;
            this.Label200.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label200.Border.TopColor = System.Drawing.Color.Black;
            this.Label200.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label200.Height = 0.2F;
            this.Label200.HyperLink = "";
            this.Label200.Left = 0.5F;
            this.Label200.Name = "Label200";
            this.Label200.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label200.Text = "Dealer";
            this.Label200.Top = 0F;
            this.Label200.Width = 0.625F;
            // 
            // Label201
            // 
            this.Label201.Border.BottomColor = System.Drawing.Color.Black;
            this.Label201.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label201.Border.LeftColor = System.Drawing.Color.Black;
            this.Label201.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label201.Border.RightColor = System.Drawing.Color.Black;
            this.Label201.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label201.Border.TopColor = System.Drawing.Color.Black;
            this.Label201.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label201.Height = 0.2F;
            this.Label201.HyperLink = "";
            this.Label201.Left = 2.375F;
            this.Label201.MultiLine = false;
            this.Label201.Name = "Label201";
            this.Label201.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label201.Text = "1";
            this.Label201.Top = 5.960464E-08F;
            this.Label201.Width = 0.3125F;
            // 
            // Label202
            // 
            this.Label202.Border.BottomColor = System.Drawing.Color.Black;
            this.Label202.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label202.Border.LeftColor = System.Drawing.Color.Black;
            this.Label202.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label202.Border.RightColor = System.Drawing.Color.Black;
            this.Label202.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label202.Border.TopColor = System.Drawing.Color.Black;
            this.Label202.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label202.Height = 0.2F;
            this.Label202.HyperLink = "";
            this.Label202.Left = 2.6875F;
            this.Label202.MultiLine = false;
            this.Label202.Name = "Label202";
            this.Label202.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label202.Text = "2";
            this.Label202.Top = 5.960464E-08F;
            this.Label202.Width = 0.3125F;
            // 
            // Label203
            // 
            this.Label203.Border.BottomColor = System.Drawing.Color.Black;
            this.Label203.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label203.Border.LeftColor = System.Drawing.Color.Black;
            this.Label203.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label203.Border.RightColor = System.Drawing.Color.Black;
            this.Label203.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label203.Border.TopColor = System.Drawing.Color.Black;
            this.Label203.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label203.Height = 0.2F;
            this.Label203.HyperLink = "";
            this.Label203.Left = 3F;
            this.Label203.MultiLine = false;
            this.Label203.Name = "Label203";
            this.Label203.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label203.Text = "3";
            this.Label203.Top = 5.960464E-08F;
            this.Label203.Width = 0.3125F;
            // 
            // Label204
            // 
            this.Label204.Border.BottomColor = System.Drawing.Color.Black;
            this.Label204.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label204.Border.LeftColor = System.Drawing.Color.Black;
            this.Label204.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label204.Border.RightColor = System.Drawing.Color.Black;
            this.Label204.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label204.Border.TopColor = System.Drawing.Color.Black;
            this.Label204.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label204.Height = 0.2F;
            this.Label204.HyperLink = "";
            this.Label204.Left = 3.3125F;
            this.Label204.MultiLine = false;
            this.Label204.Name = "Label204";
            this.Label204.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label204.Text = "4";
            this.Label204.Top = 5.960464E-08F;
            this.Label204.Width = 0.3125F;
            // 
            // Label205
            // 
            this.Label205.Border.BottomColor = System.Drawing.Color.Black;
            this.Label205.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label205.Border.LeftColor = System.Drawing.Color.Black;
            this.Label205.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label205.Border.RightColor = System.Drawing.Color.Black;
            this.Label205.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label205.Border.TopColor = System.Drawing.Color.Black;
            this.Label205.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label205.Height = 0.2F;
            this.Label205.HyperLink = "";
            this.Label205.Left = 3.625F;
            this.Label205.MultiLine = false;
            this.Label205.Name = "Label205";
            this.Label205.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label205.Text = "5";
            this.Label205.Top = 5.960464E-08F;
            this.Label205.Width = 0.3125F;
            // 
            // Label206
            // 
            this.Label206.Border.BottomColor = System.Drawing.Color.Black;
            this.Label206.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label206.Border.LeftColor = System.Drawing.Color.Black;
            this.Label206.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label206.Border.RightColor = System.Drawing.Color.Black;
            this.Label206.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label206.Border.TopColor = System.Drawing.Color.Black;
            this.Label206.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label206.Height = 0.2F;
            this.Label206.HyperLink = "";
            this.Label206.Left = 3.9375F;
            this.Label206.MultiLine = false;
            this.Label206.Name = "Label206";
            this.Label206.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label206.Text = "6";
            this.Label206.Top = 5.960464E-08F;
            this.Label206.Width = 0.3125F;
            // 
            // Label207
            // 
            this.Label207.Border.BottomColor = System.Drawing.Color.Black;
            this.Label207.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label207.Border.LeftColor = System.Drawing.Color.Black;
            this.Label207.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label207.Border.RightColor = System.Drawing.Color.Black;
            this.Label207.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label207.Border.TopColor = System.Drawing.Color.Black;
            this.Label207.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label207.Height = 0.2F;
            this.Label207.HyperLink = "";
            this.Label207.Left = 4.25F;
            this.Label207.MultiLine = false;
            this.Label207.Name = "Label207";
            this.Label207.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label207.Text = "7";
            this.Label207.Top = 5.960464E-08F;
            this.Label207.Width = 0.3125F;
            // 
            // Label208
            // 
            this.Label208.Border.BottomColor = System.Drawing.Color.Black;
            this.Label208.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label208.Border.LeftColor = System.Drawing.Color.Black;
            this.Label208.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label208.Border.RightColor = System.Drawing.Color.Black;
            this.Label208.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label208.Border.TopColor = System.Drawing.Color.Black;
            this.Label208.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label208.Height = 0.2F;
            this.Label208.HyperLink = "";
            this.Label208.Left = 4.5625F;
            this.Label208.MultiLine = false;
            this.Label208.Name = "Label208";
            this.Label208.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label208.Text = "8";
            this.Label208.Top = 5.960464E-08F;
            this.Label208.Width = 0.3125F;
            // 
            // Label209
            // 
            this.Label209.Border.BottomColor = System.Drawing.Color.Black;
            this.Label209.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label209.Border.LeftColor = System.Drawing.Color.Black;
            this.Label209.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label209.Border.RightColor = System.Drawing.Color.Black;
            this.Label209.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label209.Border.TopColor = System.Drawing.Color.Black;
            this.Label209.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label209.Height = 0.2F;
            this.Label209.HyperLink = "";
            this.Label209.Left = 4.875F;
            this.Label209.MultiLine = false;
            this.Label209.Name = "Label209";
            this.Label209.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label209.Text = "9";
            this.Label209.Top = 5.960464E-08F;
            this.Label209.Width = 0.3125F;
            // 
            // Label210
            // 
            this.Label210.Border.BottomColor = System.Drawing.Color.Black;
            this.Label210.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label210.Border.LeftColor = System.Drawing.Color.Black;
            this.Label210.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label210.Border.RightColor = System.Drawing.Color.Black;
            this.Label210.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label210.Border.TopColor = System.Drawing.Color.Black;
            this.Label210.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label210.Height = 0.2F;
            this.Label210.HyperLink = "";
            this.Label210.Left = 5.1875F;
            this.Label210.MultiLine = false;
            this.Label210.Name = "Label210";
            this.Label210.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label210.Text = "10";
            this.Label210.Top = 5.960464E-08F;
            this.Label210.Width = 0.3125F;
            // 
            // Label211
            // 
            this.Label211.Border.BottomColor = System.Drawing.Color.Black;
            this.Label211.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label211.Border.LeftColor = System.Drawing.Color.Black;
            this.Label211.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label211.Border.RightColor = System.Drawing.Color.Black;
            this.Label211.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label211.Border.TopColor = System.Drawing.Color.Black;
            this.Label211.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label211.Height = 0.2F;
            this.Label211.HyperLink = "";
            this.Label211.Left = 5.5F;
            this.Label211.MultiLine = false;
            this.Label211.Name = "Label211";
            this.Label211.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label211.Text = "11";
            this.Label211.Top = 5.960464E-08F;
            this.Label211.Width = 0.3125F;
            // 
            // Label212
            // 
            this.Label212.Border.BottomColor = System.Drawing.Color.Black;
            this.Label212.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label212.Border.LeftColor = System.Drawing.Color.Black;
            this.Label212.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label212.Border.RightColor = System.Drawing.Color.Black;
            this.Label212.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label212.Border.TopColor = System.Drawing.Color.Black;
            this.Label212.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label212.Height = 0.2F;
            this.Label212.HyperLink = "";
            this.Label212.Left = 5.8125F;
            this.Label212.MultiLine = false;
            this.Label212.Name = "Label212";
            this.Label212.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label212.Text = "12";
            this.Label212.Top = 5.960464E-08F;
            this.Label212.Width = 0.3125F;
            // 
            // Label213
            // 
            this.Label213.Border.BottomColor = System.Drawing.Color.Black;
            this.Label213.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label213.Border.LeftColor = System.Drawing.Color.Black;
            this.Label213.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label213.Border.RightColor = System.Drawing.Color.Black;
            this.Label213.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label213.Border.TopColor = System.Drawing.Color.Black;
            this.Label213.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label213.Height = 0.2F;
            this.Label213.HyperLink = "";
            this.Label213.Left = 6.125F;
            this.Label213.MultiLine = false;
            this.Label213.Name = "Label213";
            this.Label213.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label213.Text = "13";
            this.Label213.Top = 5.960464E-08F;
            this.Label213.Width = 0.3125F;
            // 
            // Label214
            // 
            this.Label214.Border.BottomColor = System.Drawing.Color.Black;
            this.Label214.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label214.Border.LeftColor = System.Drawing.Color.Black;
            this.Label214.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label214.Border.RightColor = System.Drawing.Color.Black;
            this.Label214.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label214.Border.TopColor = System.Drawing.Color.Black;
            this.Label214.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label214.Height = 0.2F;
            this.Label214.HyperLink = "";
            this.Label214.Left = 6.4375F;
            this.Label214.MultiLine = false;
            this.Label214.Name = "Label214";
            this.Label214.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label214.Text = "14";
            this.Label214.Top = 5.960464E-08F;
            this.Label214.Width = 0.3125F;
            // 
            // Label215
            // 
            this.Label215.Border.BottomColor = System.Drawing.Color.Black;
            this.Label215.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label215.Border.LeftColor = System.Drawing.Color.Black;
            this.Label215.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label215.Border.RightColor = System.Drawing.Color.Black;
            this.Label215.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label215.Border.TopColor = System.Drawing.Color.Black;
            this.Label215.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label215.Height = 0.2F;
            this.Label215.HyperLink = "";
            this.Label215.Left = 6.75F;
            this.Label215.MultiLine = false;
            this.Label215.Name = "Label215";
            this.Label215.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label215.Text = "15";
            this.Label215.Top = 5.960464E-08F;
            this.Label215.Width = 0.3125F;
            // 
            // Label216
            // 
            this.Label216.Border.BottomColor = System.Drawing.Color.Black;
            this.Label216.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label216.Border.LeftColor = System.Drawing.Color.Black;
            this.Label216.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label216.Border.RightColor = System.Drawing.Color.Black;
            this.Label216.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label216.Border.TopColor = System.Drawing.Color.Black;
            this.Label216.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label216.Height = 0.2F;
            this.Label216.HyperLink = "";
            this.Label216.Left = 7.0625F;
            this.Label216.MultiLine = false;
            this.Label216.Name = "Label216";
            this.Label216.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label216.Text = "16";
            this.Label216.Top = 5.960464E-08F;
            this.Label216.Width = 0.3125F;
            // 
            // Label217
            // 
            this.Label217.Border.BottomColor = System.Drawing.Color.Black;
            this.Label217.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label217.Border.LeftColor = System.Drawing.Color.Black;
            this.Label217.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label217.Border.RightColor = System.Drawing.Color.Black;
            this.Label217.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label217.Border.TopColor = System.Drawing.Color.Black;
            this.Label217.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label217.Height = 0.2F;
            this.Label217.HyperLink = "";
            this.Label217.Left = 7.375F;
            this.Label217.MultiLine = false;
            this.Label217.Name = "Label217";
            this.Label217.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label217.Text = "17";
            this.Label217.Top = 5.960464E-08F;
            this.Label217.Width = 0.3125F;
            // 
            // Label218
            // 
            this.Label218.Border.BottomColor = System.Drawing.Color.Black;
            this.Label218.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label218.Border.LeftColor = System.Drawing.Color.Black;
            this.Label218.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label218.Border.RightColor = System.Drawing.Color.Black;
            this.Label218.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label218.Border.TopColor = System.Drawing.Color.Black;
            this.Label218.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label218.Height = 0.2F;
            this.Label218.HyperLink = "";
            this.Label218.Left = 7.6875F;
            this.Label218.MultiLine = false;
            this.Label218.Name = "Label218";
            this.Label218.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label218.Text = "18";
            this.Label218.Top = 5.960464E-08F;
            this.Label218.Width = 0.3125F;
            // 
            // Label219
            // 
            this.Label219.Border.BottomColor = System.Drawing.Color.Black;
            this.Label219.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label219.Border.LeftColor = System.Drawing.Color.Black;
            this.Label219.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label219.Border.RightColor = System.Drawing.Color.Black;
            this.Label219.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label219.Border.TopColor = System.Drawing.Color.Black;
            this.Label219.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label219.Height = 0.2F;
            this.Label219.HyperLink = "";
            this.Label219.Left = 8F;
            this.Label219.MultiLine = false;
            this.Label219.Name = "Label219";
            this.Label219.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label219.Text = "19";
            this.Label219.Top = 5.960464E-08F;
            this.Label219.Width = 0.3125F;
            // 
            // Label220
            // 
            this.Label220.Border.BottomColor = System.Drawing.Color.Black;
            this.Label220.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label220.Border.LeftColor = System.Drawing.Color.Black;
            this.Label220.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label220.Border.RightColor = System.Drawing.Color.Black;
            this.Label220.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label220.Border.TopColor = System.Drawing.Color.Black;
            this.Label220.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label220.Height = 0.2F;
            this.Label220.HyperLink = "";
            this.Label220.Left = 8.3125F;
            this.Label220.MultiLine = false;
            this.Label220.Name = "Label220";
            this.Label220.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label220.Text = "20";
            this.Label220.Top = 5.960464E-08F;
            this.Label220.Width = 0.3125F;
            // 
            // Label221
            // 
            this.Label221.Border.BottomColor = System.Drawing.Color.Black;
            this.Label221.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label221.Border.LeftColor = System.Drawing.Color.Black;
            this.Label221.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label221.Border.RightColor = System.Drawing.Color.Black;
            this.Label221.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label221.Border.TopColor = System.Drawing.Color.Black;
            this.Label221.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label221.Height = 0.2F;
            this.Label221.HyperLink = "";
            this.Label221.Left = 8.625F;
            this.Label221.MultiLine = false;
            this.Label221.Name = "Label221";
            this.Label221.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label221.Text = "21";
            this.Label221.Top = 5.960464E-08F;
            this.Label221.Width = 0.3125F;
            // 
            // Label222
            // 
            this.Label222.Border.BottomColor = System.Drawing.Color.Black;
            this.Label222.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label222.Border.LeftColor = System.Drawing.Color.Black;
            this.Label222.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label222.Border.RightColor = System.Drawing.Color.Black;
            this.Label222.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label222.Border.TopColor = System.Drawing.Color.Black;
            this.Label222.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label222.Height = 0.2F;
            this.Label222.HyperLink = "";
            this.Label222.Left = 8.9375F;
            this.Label222.MultiLine = false;
            this.Label222.Name = "Label222";
            this.Label222.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label222.Text = "22";
            this.Label222.Top = 5.960464E-08F;
            this.Label222.Width = 0.3125F;
            // 
            // Label223
            // 
            this.Label223.Border.BottomColor = System.Drawing.Color.Black;
            this.Label223.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label223.Border.LeftColor = System.Drawing.Color.Black;
            this.Label223.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label223.Border.RightColor = System.Drawing.Color.Black;
            this.Label223.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label223.Border.TopColor = System.Drawing.Color.Black;
            this.Label223.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label223.Height = 0.2F;
            this.Label223.HyperLink = "";
            this.Label223.Left = 9.25F;
            this.Label223.MultiLine = false;
            this.Label223.Name = "Label223";
            this.Label223.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label223.Text = "23";
            this.Label223.Top = 5.960464E-08F;
            this.Label223.Width = 0.3125F;
            // 
            // Label224
            // 
            this.Label224.Border.BottomColor = System.Drawing.Color.Black;
            this.Label224.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label224.Border.LeftColor = System.Drawing.Color.Black;
            this.Label224.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label224.Border.RightColor = System.Drawing.Color.Black;
            this.Label224.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label224.Border.TopColor = System.Drawing.Color.Black;
            this.Label224.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label224.Height = 0.2F;
            this.Label224.HyperLink = "";
            this.Label224.Left = 9.5625F;
            this.Label224.MultiLine = false;
            this.Label224.Name = "Label224";
            this.Label224.Style = "text-align: center; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.Label224.Text = "24";
            this.Label224.Top = 5.960464E-08F;
            this.Label224.Width = 0.3125F;
            // 
            // Label225
            // 
            this.Label225.Border.BottomColor = System.Drawing.Color.Black;
            this.Label225.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label225.Border.LeftColor = System.Drawing.Color.Black;
            this.Label225.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label225.Border.RightColor = System.Drawing.Color.Black;
            this.Label225.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label225.Border.TopColor = System.Drawing.Color.Black;
            this.Label225.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label225.Height = 0.2F;
            this.Label225.HyperLink = "";
            this.Label225.Left = 9.875F;
            this.Label225.MultiLine = false;
            this.Label225.Name = "Label225";
            this.Label225.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label225.Text = "25";
            this.Label225.Top = 5.960464E-08F;
            this.Label225.Width = 0.3125F;
            // 
            // Label226
            // 
            this.Label226.Border.BottomColor = System.Drawing.Color.Black;
            this.Label226.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label226.Border.LeftColor = System.Drawing.Color.Black;
            this.Label226.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label226.Border.RightColor = System.Drawing.Color.Black;
            this.Label226.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label226.Border.TopColor = System.Drawing.Color.Black;
            this.Label226.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label226.Height = 0.2F;
            this.Label226.HyperLink = "";
            this.Label226.Left = 10.1875F;
            this.Label226.MultiLine = false;
            this.Label226.Name = "Label226";
            this.Label226.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label226.Text = "26";
            this.Label226.Top = 5.960464E-08F;
            this.Label226.Width = 0.3125F;
            // 
            // Label227
            // 
            this.Label227.Border.BottomColor = System.Drawing.Color.Black;
            this.Label227.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label227.Border.LeftColor = System.Drawing.Color.Black;
            this.Label227.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label227.Border.RightColor = System.Drawing.Color.Black;
            this.Label227.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label227.Border.TopColor = System.Drawing.Color.Black;
            this.Label227.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label227.Height = 0.2F;
            this.Label227.HyperLink = "";
            this.Label227.Left = 10.5F;
            this.Label227.MultiLine = false;
            this.Label227.Name = "Label227";
            this.Label227.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label227.Text = "27";
            this.Label227.Top = 5.960464E-08F;
            this.Label227.Width = 0.3125F;
            // 
            // Label228
            // 
            this.Label228.Border.BottomColor = System.Drawing.Color.Black;
            this.Label228.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label228.Border.LeftColor = System.Drawing.Color.Black;
            this.Label228.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label228.Border.RightColor = System.Drawing.Color.Black;
            this.Label228.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label228.Border.TopColor = System.Drawing.Color.Black;
            this.Label228.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label228.Height = 0.2F;
            this.Label228.HyperLink = "";
            this.Label228.Left = 10.8125F;
            this.Label228.MultiLine = false;
            this.Label228.Name = "Label228";
            this.Label228.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label228.Text = "28";
            this.Label228.Top = 5.960464E-08F;
            this.Label228.Width = 0.3125F;
            // 
            // Label229
            // 
            this.Label229.Border.BottomColor = System.Drawing.Color.Black;
            this.Label229.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label229.Border.LeftColor = System.Drawing.Color.Black;
            this.Label229.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label229.Border.RightColor = System.Drawing.Color.Black;
            this.Label229.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label229.Border.TopColor = System.Drawing.Color.Black;
            this.Label229.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label229.Height = 0.2F;
            this.Label229.HyperLink = "";
            this.Label229.Left = 11.125F;
            this.Label229.MultiLine = false;
            this.Label229.Name = "Label229";
            this.Label229.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label229.Text = "29";
            this.Label229.Top = 5.960464E-08F;
            this.Label229.Width = 0.3125F;
            // 
            // Label230
            // 
            this.Label230.Border.BottomColor = System.Drawing.Color.Black;
            this.Label230.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label230.Border.LeftColor = System.Drawing.Color.Black;
            this.Label230.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label230.Border.RightColor = System.Drawing.Color.Black;
            this.Label230.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label230.Border.TopColor = System.Drawing.Color.Black;
            this.Label230.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label230.Height = 0.2F;
            this.Label230.HyperLink = "";
            this.Label230.Left = 11.4375F;
            this.Label230.MultiLine = false;
            this.Label230.Name = "Label230";
            this.Label230.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label230.Text = "30";
            this.Label230.Top = 5.960464E-08F;
            this.Label230.Width = 0.3125F;
            // 
            // Label231
            // 
            this.Label231.Border.BottomColor = System.Drawing.Color.Black;
            this.Label231.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label231.Border.LeftColor = System.Drawing.Color.Black;
            this.Label231.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label231.Border.RightColor = System.Drawing.Color.Black;
            this.Label231.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label231.Border.TopColor = System.Drawing.Color.Black;
            this.Label231.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label231.Height = 0.2F;
            this.Label231.HyperLink = "";
            this.Label231.Left = 11.75F;
            this.Label231.MultiLine = false;
            this.Label231.Name = "Label231";
            this.Label231.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label231.Text = "31";
            this.Label231.Top = 5.960464E-08F;
            this.Label231.Width = 0.3125F;
            // 
            // Label232
            // 
            this.Label232.Border.BottomColor = System.Drawing.Color.Black;
            this.Label232.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label232.Border.LeftColor = System.Drawing.Color.Black;
            this.Label232.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label232.Border.RightColor = System.Drawing.Color.Black;
            this.Label232.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label232.Border.TopColor = System.Drawing.Color.Black;
            this.Label232.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label232.Height = 0.2F;
            this.Label232.HyperLink = "";
            this.Label232.Left = 12.125F;
            this.Label232.MultiLine = false;
            this.Label232.Name = "Label232";
            this.Label232.Style = "text-align: center; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.Label232.Text = "Total";
            this.Label232.Top = 5.960464E-08F;
            this.Label232.Width = 0.5625F;
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
            this.Line103.Height = 0.1875001F;
            this.Line103.Left = 2.694444F;
            this.Line103.LineWeight = 1F;
            this.Line103.Name = "Line103";
            this.Line103.Top = 0.006944418F;
            this.Line103.Width = 0F;
            this.Line103.X1 = 2.694444F;
            this.Line103.X2 = 2.694444F;
            this.Line103.Y1 = 0.006944418F;
            this.Line103.Y2 = 0.1944445F;
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
            this.Line104.Height = 0.1875001F;
            this.Line104.Left = 3.006944F;
            this.Line104.LineWeight = 1F;
            this.Line104.Name = "Line104";
            this.Line104.Top = 0.006944418F;
            this.Line104.Width = 0F;
            this.Line104.X1 = 3.006944F;
            this.Line104.X2 = 3.006944F;
            this.Line104.Y1 = 0.006944418F;
            this.Line104.Y2 = 0.1944445F;
            // 
            // Line105
            // 
            this.Line105.Border.BottomColor = System.Drawing.Color.Black;
            this.Line105.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line105.Border.LeftColor = System.Drawing.Color.Black;
            this.Line105.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line105.Border.RightColor = System.Drawing.Color.Black;
            this.Line105.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line105.Border.TopColor = System.Drawing.Color.Black;
            this.Line105.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line105.Height = 0.1875001F;
            this.Line105.Left = 3.319444F;
            this.Line105.LineWeight = 1F;
            this.Line105.Name = "Line105";
            this.Line105.Top = 0.006944418F;
            this.Line105.Width = 0F;
            this.Line105.X1 = 3.319444F;
            this.Line105.X2 = 3.319444F;
            this.Line105.Y1 = 0.006944418F;
            this.Line105.Y2 = 0.1944445F;
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
            this.Line106.Height = 0.1875001F;
            this.Line106.Left = 3.631944F;
            this.Line106.LineWeight = 1F;
            this.Line106.Name = "Line106";
            this.Line106.Top = 0.006944418F;
            this.Line106.Width = 0F;
            this.Line106.X1 = 3.631944F;
            this.Line106.X2 = 3.631944F;
            this.Line106.Y1 = 0.006944418F;
            this.Line106.Y2 = 0.1944445F;
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
            this.Line107.Height = 0.1875001F;
            this.Line107.Left = 3.944444F;
            this.Line107.LineWeight = 1F;
            this.Line107.Name = "Line107";
            this.Line107.Top = 0.006944418F;
            this.Line107.Width = 0F;
            this.Line107.X1 = 3.944444F;
            this.Line107.X2 = 3.944444F;
            this.Line107.Y1 = 0.006944418F;
            this.Line107.Y2 = 0.1944445F;
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
            this.Line108.Height = 0.1875001F;
            this.Line108.Left = 4.256945F;
            this.Line108.LineWeight = 1F;
            this.Line108.Name = "Line108";
            this.Line108.Top = 0.006944418F;
            this.Line108.Width = 0F;
            this.Line108.X1 = 4.256945F;
            this.Line108.X2 = 4.256945F;
            this.Line108.Y1 = 0.006944418F;
            this.Line108.Y2 = 0.1944445F;
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
            this.Line109.Height = 0.1875001F;
            this.Line109.Left = 4.569445F;
            this.Line109.LineWeight = 1F;
            this.Line109.Name = "Line109";
            this.Line109.Top = 0.006944418F;
            this.Line109.Width = 0F;
            this.Line109.X1 = 4.569445F;
            this.Line109.X2 = 4.569445F;
            this.Line109.Y1 = 0.006944418F;
            this.Line109.Y2 = 0.1944445F;
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
            this.Line110.Height = 0.1875001F;
            this.Line110.Left = 4.881945F;
            this.Line110.LineWeight = 1F;
            this.Line110.Name = "Line110";
            this.Line110.Top = 0.006944418F;
            this.Line110.Width = 0F;
            this.Line110.X1 = 4.881945F;
            this.Line110.X2 = 4.881945F;
            this.Line110.Y1 = 0.006944418F;
            this.Line110.Y2 = 0.1944445F;
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
            this.Line111.Height = 0.1875001F;
            this.Line111.Left = 5.506945F;
            this.Line111.LineWeight = 1F;
            this.Line111.Name = "Line111";
            this.Line111.Top = 0.006944418F;
            this.Line111.Width = 0F;
            this.Line111.X1 = 5.506945F;
            this.Line111.X2 = 5.506945F;
            this.Line111.Y1 = 0.006944418F;
            this.Line111.Y2 = 0.1944445F;
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
            this.Line112.Height = 0.1875001F;
            this.Line112.Left = 5.194445F;
            this.Line112.LineWeight = 1F;
            this.Line112.Name = "Line112";
            this.Line112.Top = 0.006944418F;
            this.Line112.Width = 0F;
            this.Line112.X1 = 5.194445F;
            this.Line112.X2 = 5.194445F;
            this.Line112.Y1 = 0.006944418F;
            this.Line112.Y2 = 0.1944445F;
            // 
            // Line113
            // 
            this.Line113.Border.BottomColor = System.Drawing.Color.Black;
            this.Line113.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line113.Border.LeftColor = System.Drawing.Color.Black;
            this.Line113.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line113.Border.RightColor = System.Drawing.Color.Black;
            this.Line113.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line113.Border.TopColor = System.Drawing.Color.Black;
            this.Line113.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line113.Height = 0.1875001F;
            this.Line113.Left = 5.819445F;
            this.Line113.LineWeight = 1F;
            this.Line113.Name = "Line113";
            this.Line113.Top = 0.006944418F;
            this.Line113.Width = 0F;
            this.Line113.X1 = 5.819445F;
            this.Line113.X2 = 5.819445F;
            this.Line113.Y1 = 0.006944418F;
            this.Line113.Y2 = 0.1944445F;
            // 
            // Line114
            // 
            this.Line114.Border.BottomColor = System.Drawing.Color.Black;
            this.Line114.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line114.Border.LeftColor = System.Drawing.Color.Black;
            this.Line114.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line114.Border.RightColor = System.Drawing.Color.Black;
            this.Line114.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line114.Border.TopColor = System.Drawing.Color.Black;
            this.Line114.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line114.Height = 0.1875001F;
            this.Line114.Left = 6.131945F;
            this.Line114.LineWeight = 1F;
            this.Line114.Name = "Line114";
            this.Line114.Top = 0.006944418F;
            this.Line114.Width = 0F;
            this.Line114.X1 = 6.131945F;
            this.Line114.X2 = 6.131945F;
            this.Line114.Y1 = 0.006944418F;
            this.Line114.Y2 = 0.1944445F;
            // 
            // Line115
            // 
            this.Line115.Border.BottomColor = System.Drawing.Color.Black;
            this.Line115.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line115.Border.LeftColor = System.Drawing.Color.Black;
            this.Line115.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line115.Border.RightColor = System.Drawing.Color.Black;
            this.Line115.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line115.Border.TopColor = System.Drawing.Color.Black;
            this.Line115.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line115.Height = 0.1875001F;
            this.Line115.Left = 6.444445F;
            this.Line115.LineWeight = 1F;
            this.Line115.Name = "Line115";
            this.Line115.Top = 0.006944418F;
            this.Line115.Width = 0F;
            this.Line115.X1 = 6.444445F;
            this.Line115.X2 = 6.444445F;
            this.Line115.Y1 = 0.006944418F;
            this.Line115.Y2 = 0.1944445F;
            // 
            // Line116
            // 
            this.Line116.Border.BottomColor = System.Drawing.Color.Black;
            this.Line116.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line116.Border.LeftColor = System.Drawing.Color.Black;
            this.Line116.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line116.Border.RightColor = System.Drawing.Color.Black;
            this.Line116.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line116.Border.TopColor = System.Drawing.Color.Black;
            this.Line116.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line116.Height = 0.1875001F;
            this.Line116.Left = 6.756945F;
            this.Line116.LineWeight = 1F;
            this.Line116.Name = "Line116";
            this.Line116.Top = 0.006944418F;
            this.Line116.Width = 0F;
            this.Line116.X1 = 6.756945F;
            this.Line116.X2 = 6.756945F;
            this.Line116.Y1 = 0.006944418F;
            this.Line116.Y2 = 0.1944445F;
            // 
            // Line117
            // 
            this.Line117.Border.BottomColor = System.Drawing.Color.Black;
            this.Line117.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line117.Border.LeftColor = System.Drawing.Color.Black;
            this.Line117.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line117.Border.RightColor = System.Drawing.Color.Black;
            this.Line117.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line117.Border.TopColor = System.Drawing.Color.Black;
            this.Line117.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line117.Height = 0.1875001F;
            this.Line117.Left = 7.069445F;
            this.Line117.LineWeight = 1F;
            this.Line117.Name = "Line117";
            this.Line117.Top = 0.006944418F;
            this.Line117.Width = 0F;
            this.Line117.X1 = 7.069445F;
            this.Line117.X2 = 7.069445F;
            this.Line117.Y1 = 0.006944418F;
            this.Line117.Y2 = 0.1944445F;
            // 
            // Line118
            // 
            this.Line118.Border.BottomColor = System.Drawing.Color.Black;
            this.Line118.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line118.Border.LeftColor = System.Drawing.Color.Black;
            this.Line118.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line118.Border.RightColor = System.Drawing.Color.Black;
            this.Line118.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line118.Border.TopColor = System.Drawing.Color.Black;
            this.Line118.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line118.Height = 0.1875001F;
            this.Line118.Left = 7.381945F;
            this.Line118.LineWeight = 1F;
            this.Line118.Name = "Line118";
            this.Line118.Top = 0.006944418F;
            this.Line118.Width = 0F;
            this.Line118.X1 = 7.381945F;
            this.Line118.X2 = 7.381945F;
            this.Line118.Y1 = 0.006944418F;
            this.Line118.Y2 = 0.1944445F;
            // 
            // Line119
            // 
            this.Line119.Border.BottomColor = System.Drawing.Color.Black;
            this.Line119.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line119.Border.LeftColor = System.Drawing.Color.Black;
            this.Line119.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line119.Border.RightColor = System.Drawing.Color.Black;
            this.Line119.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line119.Border.TopColor = System.Drawing.Color.Black;
            this.Line119.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line119.Height = 0.1875001F;
            this.Line119.Left = 7.694445F;
            this.Line119.LineWeight = 1F;
            this.Line119.Name = "Line119";
            this.Line119.Top = 0.006944418F;
            this.Line119.Width = 0F;
            this.Line119.X1 = 7.694445F;
            this.Line119.X2 = 7.694445F;
            this.Line119.Y1 = 0.006944418F;
            this.Line119.Y2 = 0.1944445F;
            // 
            // Line120
            // 
            this.Line120.Border.BottomColor = System.Drawing.Color.Black;
            this.Line120.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line120.Border.LeftColor = System.Drawing.Color.Black;
            this.Line120.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line120.Border.RightColor = System.Drawing.Color.Black;
            this.Line120.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line120.Border.TopColor = System.Drawing.Color.Black;
            this.Line120.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line120.Height = 0.1875001F;
            this.Line120.Left = 8.006945F;
            this.Line120.LineWeight = 1F;
            this.Line120.Name = "Line120";
            this.Line120.Top = 0.006944418F;
            this.Line120.Width = 0F;
            this.Line120.X1 = 8.006945F;
            this.Line120.X2 = 8.006945F;
            this.Line120.Y1 = 0.006944418F;
            this.Line120.Y2 = 0.1944445F;
            // 
            // Line121
            // 
            this.Line121.Border.BottomColor = System.Drawing.Color.Black;
            this.Line121.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line121.Border.LeftColor = System.Drawing.Color.Black;
            this.Line121.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line121.Border.RightColor = System.Drawing.Color.Black;
            this.Line121.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line121.Border.TopColor = System.Drawing.Color.Black;
            this.Line121.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line121.Height = 0.1875001F;
            this.Line121.Left = 8.319445F;
            this.Line121.LineWeight = 1F;
            this.Line121.Name = "Line121";
            this.Line121.Top = 0.006944418F;
            this.Line121.Width = 0F;
            this.Line121.X1 = 8.319445F;
            this.Line121.X2 = 8.319445F;
            this.Line121.Y1 = 0.006944418F;
            this.Line121.Y2 = 0.1944445F;
            // 
            // Line122
            // 
            this.Line122.Border.BottomColor = System.Drawing.Color.Black;
            this.Line122.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line122.Border.LeftColor = System.Drawing.Color.Black;
            this.Line122.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line122.Border.RightColor = System.Drawing.Color.Black;
            this.Line122.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line122.Border.TopColor = System.Drawing.Color.Black;
            this.Line122.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line122.Height = 0.1875001F;
            this.Line122.Left = 8.631945F;
            this.Line122.LineWeight = 1F;
            this.Line122.Name = "Line122";
            this.Line122.Top = 0.006944418F;
            this.Line122.Width = 0F;
            this.Line122.X1 = 8.631945F;
            this.Line122.X2 = 8.631945F;
            this.Line122.Y1 = 0.006944418F;
            this.Line122.Y2 = 0.1944445F;
            // 
            // Line123
            // 
            this.Line123.Border.BottomColor = System.Drawing.Color.Black;
            this.Line123.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line123.Border.LeftColor = System.Drawing.Color.Black;
            this.Line123.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line123.Border.RightColor = System.Drawing.Color.Black;
            this.Line123.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line123.Border.TopColor = System.Drawing.Color.Black;
            this.Line123.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line123.Height = 0.1875001F;
            this.Line123.Left = 8.944445F;
            this.Line123.LineWeight = 1F;
            this.Line123.Name = "Line123";
            this.Line123.Top = 0.006944418F;
            this.Line123.Width = 0F;
            this.Line123.X1 = 8.944445F;
            this.Line123.X2 = 8.944445F;
            this.Line123.Y1 = 0.006944418F;
            this.Line123.Y2 = 0.1944445F;
            // 
            // Line124
            // 
            this.Line124.Border.BottomColor = System.Drawing.Color.Black;
            this.Line124.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line124.Border.LeftColor = System.Drawing.Color.Black;
            this.Line124.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line124.Border.RightColor = System.Drawing.Color.Black;
            this.Line124.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line124.Border.TopColor = System.Drawing.Color.Black;
            this.Line124.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line124.Height = 0.1875001F;
            this.Line124.Left = 9.256945F;
            this.Line124.LineWeight = 1F;
            this.Line124.Name = "Line124";
            this.Line124.Top = 0.006944418F;
            this.Line124.Width = 0F;
            this.Line124.X1 = 9.256945F;
            this.Line124.X2 = 9.256945F;
            this.Line124.Y1 = 0.006944418F;
            this.Line124.Y2 = 0.1944445F;
            // 
            // Line125
            // 
            this.Line125.Border.BottomColor = System.Drawing.Color.Black;
            this.Line125.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line125.Border.LeftColor = System.Drawing.Color.Black;
            this.Line125.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line125.Border.RightColor = System.Drawing.Color.Black;
            this.Line125.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line125.Border.TopColor = System.Drawing.Color.Black;
            this.Line125.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line125.Height = 0.1875001F;
            this.Line125.Left = 9.569445F;
            this.Line125.LineWeight = 1F;
            this.Line125.Name = "Line125";
            this.Line125.Top = 0.006944418F;
            this.Line125.Width = 0F;
            this.Line125.X1 = 9.569445F;
            this.Line125.X2 = 9.569445F;
            this.Line125.Y1 = 0.006944418F;
            this.Line125.Y2 = 0.1944445F;
            // 
            // Line126
            // 
            this.Line126.Border.BottomColor = System.Drawing.Color.Black;
            this.Line126.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line126.Border.LeftColor = System.Drawing.Color.Black;
            this.Line126.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line126.Border.RightColor = System.Drawing.Color.Black;
            this.Line126.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line126.Border.TopColor = System.Drawing.Color.Black;
            this.Line126.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line126.Height = 0.1875001F;
            this.Line126.Left = 9.881945F;
            this.Line126.LineWeight = 1F;
            this.Line126.Name = "Line126";
            this.Line126.Top = 0.006944418F;
            this.Line126.Width = 0F;
            this.Line126.X1 = 9.881945F;
            this.Line126.X2 = 9.881945F;
            this.Line126.Y1 = 0.006944418F;
            this.Line126.Y2 = 0.1944445F;
            // 
            // Line127
            // 
            this.Line127.Border.BottomColor = System.Drawing.Color.Black;
            this.Line127.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line127.Border.LeftColor = System.Drawing.Color.Black;
            this.Line127.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line127.Border.RightColor = System.Drawing.Color.Black;
            this.Line127.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line127.Border.TopColor = System.Drawing.Color.Black;
            this.Line127.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line127.Height = 0.1875001F;
            this.Line127.Left = 10.19444F;
            this.Line127.LineWeight = 1F;
            this.Line127.Name = "Line127";
            this.Line127.Top = 0.006944418F;
            this.Line127.Width = 0F;
            this.Line127.X1 = 10.19444F;
            this.Line127.X2 = 10.19444F;
            this.Line127.Y1 = 0.006944418F;
            this.Line127.Y2 = 0.1944445F;
            // 
            // Line128
            // 
            this.Line128.Border.BottomColor = System.Drawing.Color.Black;
            this.Line128.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line128.Border.LeftColor = System.Drawing.Color.Black;
            this.Line128.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line128.Border.RightColor = System.Drawing.Color.Black;
            this.Line128.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line128.Border.TopColor = System.Drawing.Color.Black;
            this.Line128.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line128.Height = 0.1875001F;
            this.Line128.Left = 10.50694F;
            this.Line128.LineWeight = 1F;
            this.Line128.Name = "Line128";
            this.Line128.Top = 0.006944418F;
            this.Line128.Width = 0F;
            this.Line128.X1 = 10.50694F;
            this.Line128.X2 = 10.50694F;
            this.Line128.Y1 = 0.006944418F;
            this.Line128.Y2 = 0.1944445F;
            // 
            // Line129
            // 
            this.Line129.Border.BottomColor = System.Drawing.Color.Black;
            this.Line129.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line129.Border.LeftColor = System.Drawing.Color.Black;
            this.Line129.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line129.Border.RightColor = System.Drawing.Color.Black;
            this.Line129.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line129.Border.TopColor = System.Drawing.Color.Black;
            this.Line129.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line129.Height = 0.1875001F;
            this.Line129.Left = 11.13194F;
            this.Line129.LineWeight = 1F;
            this.Line129.Name = "Line129";
            this.Line129.Top = 0.006944418F;
            this.Line129.Width = 0F;
            this.Line129.X1 = 11.13194F;
            this.Line129.X2 = 11.13194F;
            this.Line129.Y1 = 0.006944418F;
            this.Line129.Y2 = 0.1944445F;
            // 
            // Line130
            // 
            this.Line130.Border.BottomColor = System.Drawing.Color.Black;
            this.Line130.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line130.Border.LeftColor = System.Drawing.Color.Black;
            this.Line130.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line130.Border.RightColor = System.Drawing.Color.Black;
            this.Line130.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line130.Border.TopColor = System.Drawing.Color.Black;
            this.Line130.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line130.Height = 0.1875001F;
            this.Line130.Left = 12.75694F;
            this.Line130.LineWeight = 1F;
            this.Line130.Name = "Line130";
            this.Line130.Top = 0.006944418F;
            this.Line130.Width = 0F;
            this.Line130.X1 = 12.75694F;
            this.Line130.X2 = 12.75694F;
            this.Line130.Y1 = 0.006944418F;
            this.Line130.Y2 = 0.1944445F;
            // 
            // Line131
            // 
            this.Line131.Border.BottomColor = System.Drawing.Color.Black;
            this.Line131.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line131.Border.LeftColor = System.Drawing.Color.Black;
            this.Line131.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line131.Border.RightColor = System.Drawing.Color.Black;
            this.Line131.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line131.Border.TopColor = System.Drawing.Color.Black;
            this.Line131.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line131.Height = 0.1875001F;
            this.Line131.Left = 12.06944F;
            this.Line131.LineWeight = 1F;
            this.Line131.Name = "Line131";
            this.Line131.Top = 0.006944418F;
            this.Line131.Width = 0F;
            this.Line131.X1 = 12.06944F;
            this.Line131.X2 = 12.06944F;
            this.Line131.Y1 = 0.006944418F;
            this.Line131.Y2 = 0.1944445F;
            // 
            // Line132
            // 
            this.Line132.Border.BottomColor = System.Drawing.Color.Black;
            this.Line132.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line132.Border.LeftColor = System.Drawing.Color.Black;
            this.Line132.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line132.Border.RightColor = System.Drawing.Color.Black;
            this.Line132.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line132.Border.TopColor = System.Drawing.Color.Black;
            this.Line132.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line132.Height = 0.1875001F;
            this.Line132.Left = 11.75694F;
            this.Line132.LineWeight = 1F;
            this.Line132.Name = "Line132";
            this.Line132.Top = 0.006944418F;
            this.Line132.Width = 0F;
            this.Line132.X1 = 11.75694F;
            this.Line132.X2 = 11.75694F;
            this.Line132.Y1 = 0.006944418F;
            this.Line132.Y2 = 0.1944445F;
            // 
            // Line133
            // 
            this.Line133.Border.BottomColor = System.Drawing.Color.Black;
            this.Line133.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line133.Border.LeftColor = System.Drawing.Color.Black;
            this.Line133.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line133.Border.RightColor = System.Drawing.Color.Black;
            this.Line133.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line133.Border.TopColor = System.Drawing.Color.Black;
            this.Line133.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line133.Height = 0.1875001F;
            this.Line133.Left = 11.44444F;
            this.Line133.LineWeight = 1F;
            this.Line133.Name = "Line133";
            this.Line133.Top = 0.006944418F;
            this.Line133.Width = 0F;
            this.Line133.X1 = 11.44444F;
            this.Line133.X2 = 11.44444F;
            this.Line133.Y1 = 0.006944418F;
            this.Line133.Y2 = 0.1944445F;
            // 
            // Line134
            // 
            this.Line134.Border.BottomColor = System.Drawing.Color.Black;
            this.Line134.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line134.Border.LeftColor = System.Drawing.Color.Black;
            this.Line134.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line134.Border.RightColor = System.Drawing.Color.Black;
            this.Line134.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line134.Border.TopColor = System.Drawing.Color.Black;
            this.Line134.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line134.Height = 0.1875001F;
            this.Line134.Left = 10.81944F;
            this.Line134.LineWeight = 1F;
            this.Line134.Name = "Line134";
            this.Line134.Top = 0.006944418F;
            this.Line134.Width = 0F;
            this.Line134.X1 = 10.81944F;
            this.Line134.X2 = 10.81944F;
            this.Line134.Y1 = 0.006944418F;
            this.Line134.Y2 = 0.1944445F;
            // 
            // Line135
            // 
            this.Line135.Border.BottomColor = System.Drawing.Color.Black;
            this.Line135.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line135.Border.LeftColor = System.Drawing.Color.Black;
            this.Line135.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line135.Border.RightColor = System.Drawing.Color.Black;
            this.Line135.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line135.Border.TopColor = System.Drawing.Color.Black;
            this.Line135.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line135.Height = 0.1875001F;
            this.Line135.Left = 2.381944F;
            this.Line135.LineWeight = 1F;
            this.Line135.Name = "Line135";
            this.Line135.Top = 0.006944418F;
            this.Line135.Width = 0F;
            this.Line135.X1 = 2.381944F;
            this.Line135.X2 = 2.381944F;
            this.Line135.Y1 = 0.006944418F;
            this.Line135.Y2 = 0.1944445F;
            // 
            // Label233
            // 
            this.Label233.Border.BottomColor = System.Drawing.Color.Black;
            this.Label233.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label233.Border.LeftColor = System.Drawing.Color.Black;
            this.Label233.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label233.Border.RightColor = System.Drawing.Color.Black;
            this.Label233.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label233.Border.TopColor = System.Drawing.Color.Black;
            this.Label233.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label233.Height = 0.2F;
            this.Label233.HyperLink = "";
            this.Label233.Left = 12.8125F;
            this.Label233.MultiLine = false;
            this.Label233.Name = "Label233";
            this.Label233.Style = "text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Label233.Text = "Previous";
            this.Label233.Top = 5.960464E-08F;
            this.Label233.Width = 0.5F;
            // 
            // Label235
            // 
            this.Label235.Border.BottomColor = System.Drawing.Color.Black;
            this.Label235.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label235.Border.LeftColor = System.Drawing.Color.Black;
            this.Label235.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label235.Border.RightColor = System.Drawing.Color.Black;
            this.Label235.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label235.Border.TopColor = System.Drawing.Color.Black;
            this.Label235.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label235.Height = 0.2F;
            this.Label235.HyperLink = "";
            this.Label235.Left = 2.0625F;
            this.Label235.MultiLine = false;
            this.Label235.Name = "Label235";
            this.Label235.Style = "text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label235.Text = "Code";
            this.Label235.Top = 5.960464E-08F;
            this.Label235.Width = 0.3125F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // MonthlyPolicyProduction
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 14F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Legal;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 13.45833F;
            this.Sections.Add(this.ReportHeader);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.PageFooter);
            this.Sections.Add(this.ReportFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.MonthlyPolicyProduction_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.TextBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label133)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox98)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCriterias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label236)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label237)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox79)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox81)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox82)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox83)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox84)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox85)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox86)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox87)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox88)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox89)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox90)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox91)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox92)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox93)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox94)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox95)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox96)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox97)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label234)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label200)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label201)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label202)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label203)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label204)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label205)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label206)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label207)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label208)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label209)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label210)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label211)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label212)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label213)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label214)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label215)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label216)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label217)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label218)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label219)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label220)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label221)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label222)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label223)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label224)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label225)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label226)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label227)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label228)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label229)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label230)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label231)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label232)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label233)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label235)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
