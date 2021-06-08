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
using System.Data.SqlClient;

namespace EPolicy
{
	/// <summary>
	/// Summary description for SearchLookupTableDescriptions.
	/// </summary>
	public partial class SearchLookupTableDescriptions : System.Web.UI.Page
	{
		private int _lookupTableID = 0;
		private DataTable _dtLookupTableNames = new DataTable();
		private DataTable _dtRecordsForNonValuePairLookupTable = new DataTable();
		private string[] _searchFields = new string[2];
		
		#region Page Properties
		
		public int LookupTableID
		{
			get
			{
				return this._lookupTableID;
			}
			set
			{
				this._lookupTableID = value;
			}
		}

		public DataTable DtLookupTableNames
		{
			get
			{
				return this._dtLookupTableNames;
			}
			set
			{
				this._dtLookupTableNames = value;
			}
		}

		public DataTable DtRecordsForNonValuePairLookupTable
		{
			get
			{
				return this._dtRecordsForNonValuePairLookupTable;
			}
			set
			{
				this._dtRecordsForNonValuePairLookupTable = value;
			}
		}
		
		public string[] SearchFields
		{
			get
			{
				return this._searchFields;
			}
			set
			{
				this._searchFields = value;
			}
		}

		#endregion
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			this.litPopUp.Visible = false;
            Page.Form.DefaultButton = btnSearch.UniqueID;
			
			Login.Login cp = HttpContext.Current.User as Login.Login;
			if (cp == null)
			{
				Response.Redirect("Default.aspx?001");
			}
			else
			{
				if(!cp.IsInRole("SEARCHLOOKUPTABLEDESCRIPTIONS") && !cp.IsInRole("ADMINISTRATOR"))
				{
					Response.Redirect("Default.aspx?001");
				}


                if (cp.IsInRole("LIMITEDLOOKUPTABLE"))
                    ddlLookupTables.Enabled = false;
                    

			}

			if(!Page.IsPostBack && (Request.QueryString["SelectedItem"] != null &&
				Request.QueryString["SelectedItem"].ToString() != ""))
			{
				this.InitializeProperties();
				this.InitializeControls();			
			}
			else if(!Page.IsPostBack)
			{
				this.SetDtLookupTableNamesProperty();
				this.FillLookupTablesDDL();
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
			Banner = LoadControl(@"TopBanner.ascx");
			this.Placeholder1.Controls.Add(Banner);

			//Setup Left-side Banner
			Control LeftMenu = new Control();
			LeftMenu = LoadControl(@"LeftMenu.ascx");
			this.phTopBanner1.Controls.Add(LeftMenu);

		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.grdRecords.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grdRecords_ItemCreated);
			this.grdRecords.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.grdRecords_ItemCommand);

		}

		#endregion


		#region Private Functions

		private void grdRecords_ItemCreated (
			object source, DataGridItemEventArgs e)
		{	
			if(e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem ||
				e.Item.ItemType  == ListItemType.EditItem)
			{
				TableCell tableCell = new TableCell();
				tableCell =	e.Item.Cells[4];
				Button button = new Button();
				button = (Button)tableCell.Controls[0];
				button.Attributes.Add("onclick", 
					"return confirm('Are you sure you want to delete this description?')");
			}
		}

		private void InitializeProperties()
		{
			try
			{
				this.SetLookupTableIdProperty(
					int.Parse(Request.QueryString["SelectedItem"].ToString()));
				this.SetDtLookupTableNamesProperty();
				this.SetSearchFieldProperties();
			}
			catch {/*For error subsystem use.*/;}
		}

		private void InitializeControls()
		{
			this.FillLookupTablesDDL();
			this.SetLookupTablesDdlState();
			this.SetSearchTableLabel();
			this.SetSearchFieldLabels();
		}

		private void SetSearchFieldProperties()
		{
			DataTable dtResults = 
				LookupTables.LookupTables.GetNonValuePairLookupTableSearchFields(
				this.LookupTableID, 2, false);
			            
			for(int i = 0; i <= this.SearchFields.GetUpperBound(0); i++)
			{
				if(dtResults.Rows.Count > 0 &&
						  dtResults.Rows[i] != null)
				{
					this.SearchFields[i] = 
						dtResults.Rows[i]["SearchFieldName"].ToString();
				}
				else
				{
					this.SearchFields[i] = String.Empty;
				}
			}
		}

		private void SetSearchFieldLabels()
		{
            if (this.SearchFields[0] == "MasterPolicyID")
                this.lblSearchFieldA.Text = "Corporate ID";
            else
			    this.lblSearchFieldA.Text = this.SearchFields[0];

            if (this.SearchFields[1] == "MasterPolicyDesc")
                this.lblSearchFieldB.Text = "Corporate Desc.";
            else
			    this.lblSearchFieldB.Text = this.SearchFields[1];
		}

		private void SetSearchTableLabel()
		{
			DataTable dtResults = 
				LookupTables.LookupTables.GetLookupTableNameFromTableID(
				this.LookupTableID);

			if(dtResults.Rows.Count > 0)
			{					
				this.lblSearchX.Text = "Search lookup table: '" + 
					dtResults.Rows[0]["TableName"].ToString() + "'";
			}
			else
			{
				this.lblSearchX.Text = "Search lookup table: ";
			}
		}

		private void SetLookupTablesDdlState()
		{
			this.ddlLookupTables.SelectedIndex = 0;
			if(this.LookupTableID != 0)
			{
				for(int i = 0; this.ddlLookupTables.Items.Count - 1 >= i; i++)
				{
					if (this.ddlLookupTables.Items[i].Value == 
						this.LookupTableID.ToString())
					{
						this.ddlLookupTables.SelectedIndex = i;
						i = this.ddlLookupTables.Items.Count-1;
					}
				}

                if (this.LookupTableID == 81)
                    chkGroup.Visible = true;
                else
                    chkGroup.Visible = false;
			}
		}

		private void FillLookupTablesDDL()
		{
			this.ddlLookupTables.DataSource = this.DtLookupTableNames;
			this.ddlLookupTables.DataTextField = "TableName";
			this.ddlLookupTables.DataValueField = "LookupTableID";
			this.ddlLookupTables.DataBind();
			this.ddlLookupTables.SelectedIndex = -1;
			this.ddlLookupTables.Items.Insert(0,"");
		}

		private void SetLookupTableIdProperty(int TableID)
		{
            this.LookupTableID = TableID;
		}

		private void SetDtLookupTableNamesProperty()
		{
            this.DtLookupTableNames = 
				LookupTables.LookupTables.GetNonValuePairLookupTableNames();
		}

		private void ShowMessage(string Message)
		{
			this.litPopUp.Text = 
				Utilities.MakeLiteralPopUpString(Message);
			this.litPopUp.Visible = true;
		}

		private DataTable GetRecordsGridDataTable()
		{
            string searchFieldA = (lblSearchFieldA.Text.Trim() == "Corporate ID" ?
                "MasterPolicyID" : lblSearchFieldA.Text.Trim());

            string searchFieldB = (lblSearchFieldB.Text.Trim() == "Corporate Desc." ?
                "MasterPolicyDesc" : lblSearchFieldB.Text.Trim());

            if (chkGroup.Checked)
            {
                searchFieldA = "IsGroup";
                txtSearchFieldA.Text = "1";
            }

			this.PrepareDataGrid();
			try
			{
				return 
					LookupTables.LookupTables.GetRecordsForNonValuePairLookupTable(
					int.Parse(this.ddlLookupTables.SelectedItem.Value),
                    searchFieldA, this.txtSearchFieldA.Text.Trim(),
                    searchFieldB, this.txtSearchFieldB.Text.Trim(),
					false);
			}
			catch {/*For error subsystem use.*/;}
            if (chkGroup.Checked)
            {
                txtSearchFieldA.Text = "";
            }
			return null;
		}

		protected void btnAddNew_Click(object sender, System.EventArgs e)
		{
			if(LookupTables.LookupTables.GetTableMaintenancePathFromTableID(
				int.Parse(this.ddlLookupTables.SelectedItem.Value)) != string.Empty)
			{
				Response.Redirect(
					LookupTables.LookupTables.GetTableMaintenancePathFromTableID(
					int.Parse(this.ddlLookupTables.SelectedItem.Value)));
			}
			else
			{
				this.ShowMessage("A maintenance page for this table has " +
					"not been registered in the system.  Please contact " +
					"the system administrator.");
			}
		}

		private void btnAddNew1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}

		protected void btnClear_Click(object sender, System.EventArgs e)
		{
			this.ClearInputControls();
			this.grdRecords.Visible = false;
			this.lblTotalRecords.Text = "Total records: ";
		}

		private void PrepareDataGrid()
		{
			this.grdRecords.Columns[0].HeaderText = this.lblSearchFieldA.Text.Trim();
			this.grdRecords.Columns[1].HeaderText = this.lblSearchFieldB.Text.Trim();
		}

		private void RefreshRecordsGrid(int LookupTableID, bool IndexChanged, 
			bool Delete)
		{
			DataTable dtRecords = this.GetRecordsGridDataTable();

			int currentPageIndex = this.grdRecords.CurrentPageIndex;
			this.grdRecords.CurrentPageIndex = 0;
			
			this.grdRecords.DataSource = dtRecords;
            
			Session["DtRecordsForNonValuePairLookupTable"] = dtRecords;
			
			if(IndexChanged)
			{
				this.grdRecords.CurrentPageIndex = 0;
			}
			else
			{
				this.grdRecords.DataBind();

				if(Delete)
				{
					this.grdRecords.CurrentPageIndex = 
						(this.grdRecords.PageCount - 1);
				}
				else
				{
					this.grdRecords.CurrentPageIndex = currentPageIndex;
				}
			}
            if (ddlLookupTables.SelectedItem.Text == "Charge")
            {
                this.grdCharge.DataSource = dtRecords;
                this.grdCharge.DataBind();
                this.grdRecords.Visible = false;
            }
            else
            {
                this.grdRecords.DataBind();
                this.grdRecords.Visible = true;
            }
		}

		protected void ddlLookupTables_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.ddlLookupTables.SelectedItem.Value != String.Empty)
			{
				this.LookupTableID = 
					int.Parse(this.ddlLookupTables.SelectedItem.Value);
			}
			else
			{
				this.LookupTableID = 0;
			}
			
			this.SetSearchFieldProperties();
			this.SetLookupTablesDdlState();
			this.SetSearchTableLabel();
			this.SetSearchFieldLabels();
			this.grdRecords.Visible = false;
			this.lblTotalRecords.Text = "Total records: ";
			this.ClearInputControls();
		}

		private void ClearInputControls()
		{
			this.txtSearchFieldA.Text = String.Empty;
			this.txtSearchFieldB.Text = String.Empty;
		}

		public void grdRecords_ItemCommand(object source, 
			System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(e.CommandName)
			{
				case "Select":
					this.SelectHandler(e);
					break;
				case "Delete":
					this.DeleteHandler(e);
					break;
				default: //Page
					this.PageHandler(e);
					break;
			}
		}

		private void SelectHandler(
			System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(LookupTables.LookupTables.GetTableMaintenancePathFromTableID(
				int.Parse(this.ddlLookupTables.SelectedItem.Value)) != String.Empty)
			{
                if (ddlLookupTables.SelectedItem.Text != "Charge")
				Response.Redirect(
					LookupTables.LookupTables.GetTableMaintenancePathFromTableID(
					int.Parse(
					this.ddlLookupTables.SelectedItem.Value)) + "?item=" + e.Item.Cells[3].Text);
                else
                    Response.Redirect(
                    LookupTables.LookupTables.GetTableMaintenancePathFromTableID(
                    int.Parse(
                    this.ddlLookupTables.SelectedItem.Value)) + "?item=" + e.Item.Cells[0].Text);
			}
			else
			{
				this.ShowMessage("A maintenance page for this table has " +
					"not been registered in the system.  Please contact " +
					"the system administrator.");
			}
		}

		private void DeleteHandler(
			System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				if(this.ddlLookupTables.SelectedItem.Text.Trim() 
					== "LookupTableMetadata")
				{
					LookupTables.LookupTables.Delete(
						int.Parse(this.ddlLookupTables.SelectedItem.Value),
						int.Parse(e.Item.Cells[3].Text), true);
				}
				else
				{
					LookupTables.LookupTables.Delete(
						int.Parse(this.ddlLookupTables.SelectedItem.Value),
						int.Parse(e.Item.Cells[3].Text));
				}

				this.ShowMessage(
					"'" + this.lblSearchFieldB.Text + "' '" + e.Item.Cells[1].Text.Trim() +
					"' was sucessfully deleted from lookup table '" + 
					this.ddlLookupTables.SelectedItem.Text.Trim() + "'.");

				this.RefreshRecordsGrid(
					int.Parse(this.ddlLookupTables.SelectedItem.Value), false, true);
			}
			catch(Exception ex)
			{
				this.HandleDeleteError(ex);
			}
		}

		private void HandleDeleteError(Exception Ex)
		{
			switch(Ex.GetBaseException().GetType().FullName)
			{
				case "System.Data.SqlClient.SqlException":
					SqlException sqlException = (SqlException)Ex.GetBaseException();
				switch(sqlException.Number)
				{
					case 547:
						this.ShowMessage("The vehicle model you are attempting to " +
							"delete is being referenced by one or more database " +
							"entities. Please delete any existing references to " +
							"this lookup table record before attempting to delete it.");
						break;
					default:
						this.ShowMessage("An database server error ocurred while " +
							"deleting the lookup table record.");
						break;
				}
					break;
				default:
					this.ShowMessage("An error ocurred while deleting " + 
						" the lookup table record.");
					break;
			}
		}

		private void PageHandler(
			System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if((int.Parse(e.CommandArgument.ToString()) - 1) >= 0 &&
				(int.Parse(e.CommandArgument.ToString()) - 1) <=	
				this.grdRecords.PageCount)
			{
				this.grdRecords.CurrentPageIndex = 
					int.Parse(e.CommandArgument.ToString())-1;
				this.grdRecords.DataSource = 
					(DataTable) Session["DtRecordsForNonValuePairLookupTable"];
				this.grdRecords.DataBind();
				
				this.grdRecords.SelectedIndex = -1;
			}
		}

		#endregion

		private void SortHandler()
		{
			DataTable dtFilter = (DataTable)Session["DtRecordsForNonValuePairLookupTable"];

			DataTable dt = dtFilter.Clone();

			DataRow[] dr = dtFilter.Select("","fieldB");				

			for (int rec = 0; rec<=dr.Length-1; rec++)
			{
				DataRow myRow = dt.NewRow();
				myRow["recordID"] = (string) dr[rec].ItemArray[0];
				myRow["fieldA"] = (string) dr[rec].ItemArray[1];
				myRow["fieldB"] = (string) dr[rec].ItemArray[2];

				dt.Rows.Add(myRow);
				dt.AcceptChanges();
			}

			this.grdRecords.DataSource=dt;	
			
			this.grdRecords.DataBind();	
			this.grdRecords.Visible = true;

			Session.Add("DtRecordsForNonValuePairLookupTable", dt);
			
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
            if (this.ddlLookupTables.SelectedItem.Text == "Charge")
            {
                this.grdCharge.DataSource = this.GetRecordsGridDataTable();
                Session["DtRecordsForNonValuePairLookupTable"] = this.grdCharge.DataSource;

                this.grdCharge.CurrentPageIndex = 0;

                this.grdCharge.DataBind();
                this.grdCharge.Visible = true;

                DataTable dtRecordsForNonValuePairLookupTable =
                    (DataTable)Session["DtRecordsForNonValuePairLookupTable"];

                if (dtRecordsForNonValuePairLookupTable != null &&
                    dtRecordsForNonValuePairLookupTable.Rows != null)
                {
                    this.lblTotalRecords.Text =
                        "Total records: " +
                        dtRecordsForNonValuePairLookupTable.Rows.Count.ToString();
                }
                else
                {
                    this.lblTotalRecords.Text = "Total records: ";
                }
            }
            else
            {
                grdCharge.Visible = false;
                this.PrepareDataGrid();
                this.grdRecords.DataSource = this.GetRecordsGridDataTable();

                Session["DtRecordsForNonValuePairLookupTable"] = this.grdRecords.DataSource;

                this.grdRecords.CurrentPageIndex = 0;

                this.grdRecords.DataBind();
                this.grdRecords.Visible = true;

                DataTable dtRecordsForNonValuePairLookupTable =
                    (DataTable)Session["DtRecordsForNonValuePairLookupTable"];

                if (dtRecordsForNonValuePairLookupTable != null &&
                    dtRecordsForNonValuePairLookupTable.Rows != null)
                {
                    this.lblTotalRecords.Text =
                        "Total records: " +
                        dtRecordsForNonValuePairLookupTable.Rows.Count.ToString();
                }
                else
                {
                    this.lblTotalRecords.Text = "Total records: ";
                }

                if (chkGroup.Checked)
                {
                    this.grdRecords.Columns[0].Visible = false;
                    txtSearchFieldA.Text = "";
                }
                else
                    this.grdRecords.Columns[0].Visible = true;
            }
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			 Response.Redirect("LookupTableMaintenance.aspx");
		}
				

//		private void btnAddNew_Click(object sender, System.Web.UI.ImageClickEventArgs e)
//		{
//			if(LookupTables.LookupTables.GetTableMaintenancePathFromTableID(
//				int.Parse(this.ddlLookupTables.SelectedItem.Value)) != string.Empty)
//			{
//				Response.Redirect(
//					LookupTables.LookupTables.GetTableMaintenancePathFromTableID(
//					int.Parse(this.ddlLookupTables.SelectedItem.Value)));
//			}
//			else
//			{
//				this.ShowMessage("A maintenance page for this table has " +
//					"not been registered in the system.  Please contact " +
//					"the system administrator.");
//			}
//		}
}
}