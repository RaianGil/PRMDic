using DataDynamics;
using WebMail = System.Web.Mail;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Mail;
using System.Net.Mime;
using Baldrich.DBRequest;
using EPolicy.XmlCooker;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy.LookupTables;
using EPolicy.TaskControl;
using EPolicy2.Reports;
using EPolicy;
using Microsoft.Reporting.WebForms;

namespace EPolicy
{
/// <summary>
/// Summary description for PolicyReport.
/// </summary>
public partial class PolicyReport : System.Web.UI.Page
{
	private Control LeftMenu;
    private DataTable dt;
    private string agency = "";

	protected void Page_Load(object sender, System.EventArgs e)
	{
        DataTable dtAgency = TaskControl.Policy.GetAgency();

		this.litPopUp.Visible = false;
        Page.Form.DefaultButton = Button2.UniqueID;

		Login.Login cp = HttpContext.Current.User as Login.Login;
		if (cp == null)
		{
			Response.Redirect("HomePage.aspx?001");
		}
		else
		{
			if(!cp.IsInRole("POLICYREPORT") && !cp.IsInRole("ADMINISTRATOR"))
			{
				Response.Redirect("HomePage.aspx?001");
			}
		}

		if(!IsPostBack)
		{
			EnableControl();
            MultipleSelection1.CreateCheckBox(dtAgency, "AgencyDesc", "AgencyDesc");
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
		
		/*LeftMenu = new Control();
		LeftMenu = LoadControl(@"LeftMenu.ascx");
		//((Baldrich.BaldrichWeb.Components.MenuCustomers)LeftMenu).Height = "534px";
		phTopBanner1.Controls.Add(LeftMenu);*/

		//Load DownDropList
		DataTable dtCompanyDealer	=    LookupTables.LookupTables.GetTable("CompanyDealer");
		DataTable dtInsuranceCompany	= LookupTables.LookupTables.GetTable("InsuranceCompany");

		//CompanyDealer
		/*ddlDealer.DataSource = dtCompanyDealer;
		ddlDealer.DataTextField = "CompanyDealerDesc";
		ddlDealer.DataValueField = "CompanyDealerID";
		ddlDealer.DataBind();
		ddlDealer.SelectedIndex = -1;
		ddlDealer.Items.Insert(0,"");

		//InsuranceCompany
		ddlInsuranceCompany.DataSource = dtInsuranceCompany;
		ddlInsuranceCompany.DataTextField = "InsuranceCompanyDesc";
		ddlInsuranceCompany.DataValueField = "InsuranceCompanyID";
		ddlInsuranceCompany.DataBind();
		ddlInsuranceCompany.SelectedIndex = -1;
		ddlInsuranceCompany.Items.Insert(0,"");*/

		

	}
	
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{    

	}
	#endregion

	/*private void btnPrint_Click(object sender, System.Web.UI.ImageClickEventArgs e)
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

		switch(rblPolicyNotifications.SelectedItem.Value)       
		{         
			case "0":   
				AutoPolicyReport();
				break;

			case "1":   
				PaymentCertificateLetterReport();
				break; 
		}
	}*/

	private void FieldVerify()
	{
		string errorMessage = String.Empty;
		bool found = false;

        if (DtEmailResults.Items.Count != 0)
        {
            int chk = 0;
            int unchk = 0;
            for (int i = 0; i <= DtEmailResults.Items.Count - 1; i++)
            {
                if (((System.Web.UI.WebControls.CheckBox)DtEmailResults.Items[i].Cells[11].FindControl("chkSelect")).Checked)
                    chk = chk + 1;
                else
                    unchk = unchk + 1;
            }
            if (unchk == DtEmailResults.Items.Count)
		    {
			errorMessage = "Please select at least 1 client.";
			found = true;
		    }
        }
		
		//throw the exception.
		if (errorMessage != String.Empty)
		{
			throw new Exception(errorMessage);
		}

        return;
	}

	private void AutoPolicyReport()
	{
        //EPolicy2.Reports.AutoPolicy appAutoreport = new EPolicy2.Reports.AutoPolicy();
        //DataTable dt = appAutoreport.AutoPolicyReport(txtBegDate.Text,TxtEndDate.Text,ddlDealer.SelectedItem.Value.Trim(),ddlInsuranceCompany.SelectedItem.Value.Trim(),ddlDateType.SelectedItem.Value.Trim());

        //try
        //{
        //    if (dt.Rows.Count == 0)
        //    {
        //        throw new Exception("Don't exist any information for this report");
        //    }

        //    DataDynamics.ActiveReports.ActiveReport3 rpt = new  AutoPolicyReport(txtBegDate.Text,TxtEndDate.Text,"Premium Written By Company Dealer & Insurance Company",ChkSummary.Checked);

        //    //rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
		
        //    rpt.DataSource = dt;
        //    rpt.DataMember = "Report";
        //    rpt.Run(false);

        //    Session.Add("Report",rpt);
        //    Session.Add("FromPage","PolicyReport.aspx");
        //    Response.Redirect("ActiveXViewer.aspx",false);
        //}
        //catch (Exception exp)
        //{
        //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
        //    this.litPopUp.Visible = true;
        //    return;
        //}
	}

	private void PaymentCertificateLetterReport()
	{
        //EPolicy2.Reports.AutoPolicy appAutoreport = new EPolicy2.Reports.AutoPolicy();
        //DataTable dt = appAutoreport.PaymentCertificationLetterReport(txtBegDate1.Text,TxtEndDate1.Text);

        //try
        //{
        //    if (dt.Rows.Count == 0)
        //    {
        //        throw new Exception("Don't exist any information for this report");
        //    }

        //    DataDynamics.ActiveReports.ActiveReport3 rpt = new PaymentCertificateReport(txtBegDate1.Text, TxtEndDate1.Text, "Payment Certificate Letter Report", ChkSummary.Checked);

        //    //rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
		
        //    rpt.DataSource = dt;
        //    rpt.DataMember = "Report";
        //    rpt.Run(false);

        //    Session.Add("Report",rpt);
        //    Session.Add("FromPage","PolicyReport.aspx");
        //    Response.Redirect("ActiveXViewer.aspx",false);
        //}
        //catch (Exception exp)
        //{
        //    this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
        //    this.litPopUp.Visible = true;
        //    return;
        //}
	}

	protected void rblPolicyReports_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		EnableControl();
	}

	private void EnableControl()
	{
        LblDate.Visible = true;
        txtSearchDate.Visible = true;
        btnPrint.Visible = false;
        btnSendEmail.Visible = false;
        btnSelectAll.Visible = false;
        btnDeselect.Visible = false;
        btnSelectAll2.Visible = false;
        btnDeselect2.Visible = false;
        DtEmailResults.Visible = false;
        DtCheckEmailResults.Visible = false;
        LblError.Visible = false;
        LblEmailList.Visible = false;
        DtEmailResults = null;
	}

	protected void Button2_Click(object sender, System.EventArgs e)
	{
        DtCheckEmailResults.Visible = false;

        Login.Login cp = HttpContext.Current.User as Login.Login;
        int userID = 0;

        try
        {
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Could not parse user id from cp.Identity.Name.", ex);
        }

        PopulateDataTable(false);

        Session.Remove("dt");
        Session.Add("dt", dt);

        if (dt.Rows.Count != 0)
        {
            LblEmailList.Visible = true;
            LblError.Visible = false;
            btnSendEmail.Visible = true;
            btnPrint.Visible = true;
            btnSelectAll.Visible = true;
            btnDeselect.Visible = true;
            btnSelectAll2.Visible = false;
            btnDeselect2.Visible = false;
            DtEmailResults.Visible = true;
            DtEmailResults.DataSource = dt;
            DtEmailResults.DataBind();
        }
        else
        {
            DtEmailResults.DataSource = null;
            DtEmailResults.DataBind();

            LblError.Visible = true;
            LblError.Text = "Could not find a match for your search criteria, please try again.";
        }

            LblEmailList.Text = "Total Cases: " + dt.Rows.Count.ToString();
            DtEmailResults.CurrentPageIndex = 0;

            if (dt.Rows.Count > 35)
            {
                btnSelectAll2.Visible = true;
                btnDeselect2.Visible = true;
            }
            else
            {
                btnSelectAll2.Visible = false;
                btnDeselect2.Visible = false;
            }

		/*switch(rblPolicyReports.SelectedItem.Value)       
		{         
			case "0":   
				AutoPolicyReport();
				break;

			case "1":   
				PaymentCertificateLetterReport();
				break; 
		}*/
	}

	protected void BtnExit_Click(object sender, System.EventArgs e)
	{
		Session.Clear();
		Response.Redirect("MainMenu.aspx");
	}

    protected void DtEmailResults_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        //RPR 2004-05-17
        Login.Login cp = HttpContext.Current.User as Login.Login;
        int userID = 0;

        try
        {
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Could not parse user id from cp.Identity.Name.", ex);
        }
        
        if (e.CommandName.ToString() == "Select")
        {
            int i = int.Parse(e.Item.Cells[1].Text);
            TaskControl.TaskControl taskControl = TaskControl.TaskControl.GetTaskControlByTaskControlID(i, userID);

            Session.Clear();
            Session["TaskControl"] = taskControl;
            int popup = taskControl.TaskControlID;

            if (e.Item.Cells[3].Text == "PP" || e.Item.Cells[3].Text == "PE")
            {
                string js = "<script language=javascript> javascript:popwindow=window.open('Policies.aspx? + popup','popwindow','toolbar=no,location=center,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width=1024,height=768');popwindow.focus(); </script>";
                Response.Write(js);
            }
            else
            {
                string js = "<script language=javascript> javascript:popwindow=window.open('CorporatePolicyQuote.aspx? + popup','popwindow','toolbar=no,location=center,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width=1024,height=768');popwindow.focus(); </script>";
                Response.Write(js);
            }

            //Response.Redirect("Policies.aspx?" + taskControl.TaskControlID, true);
        }
        else
        {
            string filepath;

            int i = int.Parse(e.Item.Cells[1].Text);
            TaskControl.TaskControl taskControl = TaskControl.TaskControl.GetTaskControlByTaskControlID(i, userID);

            Session.Clear();
            Session["TaskControl"] = taskControl;

            if (int.Parse(rblPolicyNotifications.SelectedValue.ToString()) == 0)
            {
                filepath = PrintActiveReport(e.Item);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('exportfiles/" + filepath + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
            }
            else
            {
                filepath = PrintReport(e.Item);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('exportfiles/" + filepath + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
            }

        }
}

    /*public void lbtnPreview_Click(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        }*/

    private void Deselect()
    {
        for (int i = 0; i <= DtEmailResults.Items.Count - 1; i++)
        {
            ((System.Web.UI.WebControls.CheckBox)DtEmailResults.Items[i].Cells[6].FindControl("chkSelect")).Checked = false;
        }
    }

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        Deselect();

        for (int i = 0; i <= DtEmailResults.Items.Count - 1; i++)
        {
            ((System.Web.UI.WebControls.CheckBox)DtEmailResults.Items[i].Cells[6].FindControl("chkSelect")).Checked = true;
        }
    }
    protected void btnDeselect_Click(object sender, EventArgs e)
    {
        Deselect();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        List<string> mergePaths = new List<string>();
        string ProcessedPath = System.Configuration.ConfigurationSettings.AppSettings["ExportsFilesPathName"];
        string fileName;

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

        switch (int.Parse(rblPolicyNotifications.SelectedValue))
        {
            case 1: fileName = "Avisos_Renovacion_Poliza_Impericia_Medica.";
                break;
            case 2: fileName = "Avisos_Renovacion_Poliza_Impericia_Medica.";
                break;
            case 3: fileName = "Avisos_Cancelacion_Poliza_Impericia_Medica";
                break;
            default: fileName = "Avisos_Pago_Poliza_Impericia_Medica";
                break;
        }

        /* REPORT PRINTING (PrintReport(DataGridItem))
        mergePaths = ImprimirQuote1(mergePaths);
        */
        foreach (DataGridItem item in DtEmailResults.Items)
        {
            switch (int.Parse(rblPolicyNotifications.SelectedValue))
            {
                case 0: if (((System.Web.UI.WebControls.CheckBox)item.Cells[11].FindControl("chkSelect")).Checked)
                        mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + PrintActiveReport(item));
                    break;
                default:
                    if (((System.Web.UI.WebControls.CheckBox)item.Cells[11].FindControl("chkSelect")).Checked)
                        mergePaths.Add(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + PrintReport(item));
                    break;
            }
        }

        CreatePDFBatch mergeFinal = new CreatePDFBatch();
        string FinalFile = "";

        FinalFile = mergeFinal.MergePDFFiles(mergePaths, ProcessedPath, fileName);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('ExportFiles/" + FinalFile + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
    }
    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        Login.Login cp = HttpContext.Current.User as Login.Login;
        int userID = 0;

        try
        {
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Could not parse user id from cp.Identity.Name.", ex);
        }

        SendEmail();

        /*
        try
        {
            

        }
        catch (Exception exp)
        {
            this.litPopUp.Text = Utilities.MakeLiteralPopUpString("" + exp.Message);
            this.litPopUp.Visible = true;
            return;
        }*/

        /*switch (rblPolicyNotifications.SelectedItem.Value)
        {
            case "0":
                AutoPolicyReport();
                break;

            case "1":
                PaymentCertificateLetterReport();
                break;
        }*/

    }

    private void SendEmail()
    {
        //PopulateDataTable(false);
        EPolicy.TaskControl.Mail SM = new EPolicy.TaskControl.Mail();
        string filepath;
        int index = 0;

        Login.Login cp = HttpContext.Current.User as Login.Login;
        int userID = 0;

        try
        {
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Could not parse user id from cp.Identity.Name.", ex);
        }

        string msg = "";

        switch (int.Parse(rblPolicyNotifications.SelectedValue))
        {
            case 1: SM.MailSubject = "Aviso de Renovacion Poliza Impericia Medica.";
                break;
            case 2: SM.MailSubject = "Aviso de Renovacion Poliza Impericia Medica.";
                break;
            case 3: SM.MailSubject = "Aviso de Cancelacion Poliza Impericia Medica";
                break;
            default: SM.MailSubject = "Aviso de Pago Poliza Impericia Medica";
                break;
        }

        //TEMPORARY SOLUTION
        SM.MailFrom = "system@prmdic.net";
        
        SM.MailBody = ""; /*"<html>" + "\r\n" +
        "<body>" + "\r\n" +
            "<p>" + "\r\n" +
                "<span style=" + "font-size:10px;" + ">Este es un mensaje enviado por el Sistema Autom&aacute;tico de mensaje de ePMS.</span></p>" + "\r\n" +
            "<p>" + "\r\n" +
                "<br />" + "\r\n" +
                "<span style=" + "font-size:10px;" + "><strong>AVISO DE CONFIDENCIALIDAD</strong>: Esta comunicaci&oacute;n contiene  informacion  propiedad  de  Puerto Rico Medical Defense Insurance Company clasificada como privilegiada, confidencial y exenta de divulgaci&oacute;n. La informaci&oacute;n es para uso exclusivo del individuo o entidad a quien est&aacute; dirigida. Si usted no es el destinatario, el empleado o el agente a quien se  le  confi&oacute; la responsabilidad de hacer llegar el mensaje al destinatario, debe percatarse que la divulgaci&oacute;n, copia, distribuci&oacute;n o accion tomaba basada en el contenido de esta transmisi&oacute;n est&aacute; estrictamente prohibida. Si ha recibido esta comunicaci&oacute;n por error,  favor de borrarla  y  notificar al remitente inmediatamente.  Cualquier uso indebido  de  la  informaci&oacute;n contenida  en  este mensaje ser&aacute; sancionado bajo las leyes aplicables.</span></p>" + "\r\n" +
            "<p>" + "\r\n" +
                "<br />" + "\r\n" +
                "<span style=" + "font-size:10px;" + "><strong>CONFIDENTIALITY NOTE</strong>: This communication and any attachments here to contain information property  of  Puerto Rico Medical Defense Insurance Company, classified as privileged, confidential and exempt from disclosure. The information is intended solely  for the use of the individual  or  entity to which it is addressed.  If you  are  not the intended  recipient  or  the  employee or agent entrusted with the responsibility of delivering the message  to  the intended recipient,  be aware that any disclosure,  copying, distribution  or  action taken in based on the contents  of  this transmission  is  strictly  prohibited. If  you  have received this communication by mistake,  please  delete and notify  the  sender  immediately.  Any unauthorized  use  of  the information contained herein will be sanctioned under applicable laws.</span></p>" + "\r\n" +
            "<hr />" + "\r\n" +
        "</body>" + "\r\n" +
        "</html>";*/

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

        if (int.Parse(rblPolicyNotifications.SelectedValue) > 0)
        {
            PopulateDataTable(false);
            Session["Email"] = false;
            foreach (DataGridItem item in DtEmailResults.Items)
            {
                if (((System.Web.UI.WebControls.CheckBox)item.Cells[11].FindControl("chkSelect")).Checked)
                {
                    SM.MailTo = item.Cells[5].Text.Trim();
                    filepath = Server.MapPath("exportfiles\\" + PrintReport(item));
                    SM.MailAttachment = filepath;
                    msg = SM.SendHTMLMail();
                    Policy.UpdateEmailFlags(int.Parse(item.Cells[1].Text), item.Cells[2].Text.Trim(), int.Parse(rblPolicyNotifications.SelectedValue));
                    History(int.Parse(item.Cells[1].Text), userID);
                    dt.Rows.RemoveAt(index);
                }
                else index += 1;

                if (SM.fail) //Incorrect email, though it needs to be revised
                {
                    index += 1;
                }
            }
        }
        else
        {
            PopulateDataTable(true);
            Session["Email"] = true;
            foreach (DataGridItem item in DtEmailResults.Items)
            {
                if (((System.Web.UI.WebControls.CheckBox)item.Cells[11].FindControl("chkSelect")).Checked)
                {
                    filepath = Server.MapPath("exportfiles\\" + PrintActiveReport(item));
                    SM.MailAttachment = filepath;
                    SM.MailTo = item.Cells[5].Text;
                    msg = SM.SendHTMLMail();
                    History(int.Parse(item.Cells[1].Text), userID);
                    dt.Rows.RemoveAt(index);
                }
                else index += 1;

                //if (dt.Rows.Count > 0) //Incorrect email, thought it needs to be revised
                //{
                //    index += 1;
            }
        }

        if (int.Parse(rblPolicyNotifications.SelectedValue.ToString()) > 0)
        {
            DtEmailResults.DataSource = dt;
            DtEmailResults.DataBind();

            if (DtEmailResults.Items.Count > 0)
            {
                /*DtEmailResults.Visible = false;
                DtFailedEmailResults.Visible = true;
                DtFailedEmailResults.DataBind();*/
                LblError.Text = "Unable to send emails.";
                return;
            }
            else
            {
                this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Emails were sent successfully.");
                this.litPopUp.Visible = true;
             
            }

            if (DtEmailResults.Items.Count == 0)
            {
                DtEmailResults.Visible = false;
                btnPrint.Visible = false;
                btnSendEmail.Visible = false;
                btnSelectAll.Visible = false;
                btnDeselect.Visible = false;
                btnSelectAll2.Visible = false;
                btnDeselect2.Visible = false;
                LblEmailList.Text = "Total Cases: 0";
            }
            else
                LblEmailList.Text = "Total Cases: " + dt.Rows.Count.ToString();
        }
        else if (index > 0)
        {
            DtEmailResults.DataSource = dt;
            DtEmailResults.DataBind();

            this.litPopUp.Text = Utilities.MakeLiteralPopUpString("Emails were sent successfully.");
            this.litPopUp.Visible = true;
        }
        else
        {
            this.litPopUp.Text = Utilities.MakeLiteralPopUpString("There were problems sending emails.");
            this.litPopUp.Visible = true;
        }
        return;

    }
            /*"\r\n" +
                /*"Se ha creado la cotizaci?n # " + this.TaskControlID.ToString().Trim() + "\r\n" + "\r\n" +
                "Nombre del Cliente: " + this.Customer.FirstName.Trim() + " " + this.Customer.LastName1.Trim() + "\r\n" +
                "Agencia: " + LookupTables.LookupTables.GetDescription("Agency", this.Agency) + "\r\n" +
                "Creado Por: " + this.EnteredBy.Trim() + "\r\n" + "\r\n" + "\r\n" +
                "Este es un mensaje enviado por el Sistema Autom?tico de mensaje de ePMS." + "\r\n" + "\r\n" + "\r\n" +
            "AVISO DE CONFIDENCIALIDAD: Esta comunicaci?n contiene  informacion  propiedad  de  Puerto Rico Medical Defense Insurance Company." + "\r\n" +
            "clasificada como privilegiada, confidencial y exenta de divulgaci?n. La informaci?n es para uso exclusivo del individuo o entidad" + "\r\n" +
            "a quien est? dirigida. Si usted no es el destinatario, el empleado o el agente a quien se  le  confi? la responsabilidad de hacer" + "\r\n" +
            "llegar el mensaje al destinatario, debe percatarse que la divulgaci?n, copia, distribuci?n o accion tomaba basada en el contenido" + "\r\n" +
            "de esta transmisi?n est? estrictamente prohibida. Si ha recibido esta comunicaci?n por error,  favor de borrarla  y  notificar al" + "\r\n" +
            "remitente inmediatamente.  Cualquier uso indebido  de  la  informaci?n contenida  en  este mensaje ser? sancionado bajo las leyes" + "\r\n" +
            "aplicables." + "\r\n" + "\r\n" +
            "CONFIDENTIALITY NOTE: This communication and any attachments here to contain information property  of  Puerto Rico Medical Defense" + "\r\n" +
            "Insurance Company, classified as privileged, confidential and exempt from disclosure. The information is intended solely  for the" + "\r\n" +
            "use of the individual  or  entity to which it is addressed.  If you  are  not the intended  recipient  or  the  employee or agent" + "\r\n" +
            "entrusted with the responsibility of delivering the message  to  the intended recipient,  be aware that any disclosure,  copying," + "\r\n" +
            "distribution  or  action taken in based on the contents  of  this transmission  is  strictly  prohibited. If  you  have received" + "\r\n" +
            "this communication by mistake,  please  delete and notify  the  sender  immediately.  Any unauthorized  use  of  the information" + "\r\n" +
            "contained herein will be sanctioned under applicable laws.";*/ 
    
    public void PopulateDataTable(bool check)
    {
        if (MultipleSelection1.sText.Trim() != "")
        {
            string[] agencydesc = MultipleSelection1.sText.Split(',');

            for (int i = 0; agencydesc.Length - 1 >= i; i++)
            {
                if (i == 0)
                    agency = " and (AgencyDesc='" + agencydesc[i].Trim() + "'";
                else
                    agency = agency + " or AgencyDesc='" + agencydesc[i].Trim() + "'";
            }
            agency = agency + ")";
        }

        if (!check)
        dt = TaskControl.Policy.GetEmails(txtSearchDate.Text.Trim(),
                                 TxtPolicyNo.Text.Trim(), TxtPolicyType.Text.Trim(),
                                agency.Trim(), int.Parse(rblPolicyNotifications.SelectedValue));
        else
        dt = TaskControl.Policy.GetEmails(txtSearchDate.Text.Trim(),
                                     TxtPolicyNo.Text.Trim(), TxtPolicyType.Text.Trim(),
                                    agency.Trim(), 0);
    }

    public string PrintReport(DataGridItem item)
    {
        TaskControl.Policy taskControl = (TaskControl.Policy)Session["TaskControl"];

        try
        {
            ReportViewer viewer = new ReportViewer();
            viewer.LocalReport.DataSources.Clear();
            viewer.ProcessingMode = ProcessingMode.Local;
            switch (int.Parse(rblPolicyNotifications.SelectedValue))
            {
                case 1: viewer.LocalReport.ReportPath = Server.MapPath("Reports/RenewalNotice.rdlc");
                    break;
                case 2: viewer.LocalReport.ReportPath = Server.MapPath("Reports/RenewalNotice.rdlc");
                    break;
                case 3: viewer.LocalReport.ReportPath = Server.MapPath("Reports/CancellationNotice.rdlc");
                    break;
            }

            /*ReportParameterInfoCollection paramCol = viewer.LocalReport.GetParameters();
            ReportParameter rp1 = new ReportParameter(paramCol[0].Name, DtEmailResults.Items[0].Cells[6].Text.Trim());
            ReportParameter rp2 = new ReportParameter(paramCol[1].Name, DtEmailResults.Items[0].Cells[7].Text.Trim());
            ReportParameter rp3 = new ReportParameter(paramCol[2].Name, DtEmailResults.Items[0].Cells[3].Text.Trim());
            ReportParameter rp4 = new ReportParameter(paramCol[3].Name, DtEmailResults.Items[0].Cells[2].Text.Trim());
            ReportParameter rp5 = new ReportParameter(paramCol[4].Name, agency);
            ReportParameter rp6 = new ReportParameter(paramCol[5].Name, rblPolicyNotifications.SelectedValue);

            viewer.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6 });*/

            DataSet1TableAdapters.GetEmailListTableAdapter ta = new DataSet1TableAdapters.GetEmailListTableAdapter();
            DataSet1.GetEmailListDataTable dt = new DataSet1.GetEmailListDataTable();

            if (txtSearchDate.Text == "")
                txtSearchDate.Text = DateTime.Now.ToShortDateString();

            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("insuranceCompany", taskControl.InsuranceCompany.ToString());
            viewer.LocalReport.SetParameters(param);
            viewer.LocalReport.Refresh();

            ta.Fill(dt, txtSearchDate.Text.Trim(), item.Cells[2].Text.Trim(), item.Cells[3].Text.Trim(),
                    agency, int.Parse(rblPolicyNotifications.SelectedValue));

            Microsoft.Reporting.WebForms.ReportDataSource rptDataSource = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1_GetEmailList", dt);
            viewer.LocalReport.DataSources.Add(rptDataSource);
            viewer.LocalReport.Refresh();

            // Variables 
            Warning[] warnings;
            string[] streamIds;
            string mimeType;
            string encoding = string.Empty;
            string extension;
            string fileName = dt.Rows[0]["CustomerName"].ToString().Trim() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString();  
            string _FileName = dt.Rows[0]["CustomerName"].ToString().Trim() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + ".pdf";
            //??
            if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName))
                File.Delete(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName);

            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            using (FileStream fs = new FileStream(System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            //CreatePDFBatch pdfbatch = new CreatePDFBatch();
            //string reportList = pdfbatch.AppendTextToPDF(SetContractNoArray(), "Ciudad Jardin", "Calle Cundeamor #168", "Gurabo, P.R. 00778",
            //System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"] + _FileName, ddlMedico.SelectedItem.Text.Trim());

            //string onlyFileName = System.IO.Path.GetFileName(reportList);
            return _FileName;
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key", "window.open('Processed/" + onlyFileName + "','Reports','addressbar=no,status=1,menubar=0,scrollbars=1,resizable=1,copyhistory=no,width=900,height=700');", true);
        }
        catch (Exception ecp)
        {
            throw new Exception(ecp.Message);
        }
    }

    public string PrintActiveReport(DataGridItem item)
    {
        Policy policy = new Policy();
        ExportFile expFile = new ExportFile();
        ActiveReport3 doc = (ActiveReport3)Session["Report"];

        DataTable rptDt = TaskControl.Policy.GetEmails(txtSearchDate.Text.Trim(), item.Cells[2].Text.Trim(), item.Cells[3].Text.Trim(), 
                                          agency, 0);

        Login.Login cp = HttpContext.Current.User as Login.Login;
        int userID = 0;

        try
        {
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Could not parse user id from cp.Identity.Name.", ex);
        }
        

        string _FileName = System.Configuration.ConfigurationManager.AppSettings["ExportsFilesPathName"]
        + rptDt.Rows[0]["CustomerName"].ToString().Trim() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + ".pdf";
        string _fileName = rptDt.Rows[0]["CustomerName"].ToString().Trim() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + ".pdf";

        //TaskControl.Policy taskControl = TaskControl.Policies.GetPolicyByTaskControlID(int.Parse(item.Cells[1].Text), policy);

        TaskControl.Policy taskControl = (TaskControl.Policies)TaskControl.TaskControl.GetTaskControlByTaskControlID(int.Parse(rptDt.Rows[0]["TaskControlID"].ToString().Trim()), userID);
        taskControl.Mode = (int)TaskControl.TaskControl.TaskControlMode.CLEAR;
        Session["TaskControl"] = taskControl;

        DataDynamics.ActiveReports.ActiveReport3 rpt = null;
        //DataDynamics.ActiveReports.ActiveReport3 rpt2 = null;

        rpt = new EPolicy2.Reports.PRMdic.Invoice(taskControl, true);
        rpt.Document.Printer.PrinterName = "";
        rpt.Run(false);

        //rpt2 = new EPolicy2.Reports.PRMdic.RenewalEndorsement(taskControl, true);
        //rpt2.Document.Printer.PrinterName = "";
        //rpt2.Run(false);
        //rpt.Document.Pages.InsertRange(rpt.Document.Pages.Count, rpt2.Document.Pages);

        Session.Remove("LookUpTables");
        Session.Add("Report", rpt);
        expFile.ExportToPDF(rpt.Document, _FileName);

        return _fileName;
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        DtEmailResults.Visible = false;

        Login.Login cp = HttpContext.Current.User as Login.Login;
        int userID = 0;

        try
        {
            userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Could not parse user id from cp.Identity.Name.", ex);
        }

        PopulateDataTable(true);

        Session.Remove("dt");
        Session.Add("dt", dt);

        if (dt.Rows.Count != 0)
        {
            LblEmailList.Visible = true;
            LblError.Visible = false;
            btnSendEmail.Visible = true;
            btnPrint.Visible = false;
            btnSelectAll.Visible = false;
            btnDeselect.Visible = false;
            btnSelectAll2.Visible = false;
            btnDeselect2.Visible = false;
            DtCheckEmailResults.Visible = true;
            DtCheckEmailResults.DataSource = dt;
            DtCheckEmailResults.DataBind();
        }
        else
        {
            DtCheckEmailResults.DataSource = null;
            DtCheckEmailResults.DataBind();

            LblError.Visible = true;
            LblError.Text = "Could not find a match for your search criteria, please try again.";
        }

        LblEmailList.Text = "Total Cases: " + dt.Rows.Count.ToString();
    }

    private void History(int taskControlID, int userID)
    {
        Audit.History history = new Audit.History();
        string subject;

        switch (int.Parse(rblPolicyNotifications.SelectedValue))
        {
            case 1:
                {
                    history.Actions = "EMAIL(30)";
                    subject = "AVISO RENOVACION 30 DIAS";
                }
                break;
            case 2:
                {
                    history.Actions = "EMAIL(15)";
                    subject = "AVISO RENOVACION 15 DIAS";}
                break;
            case 3:
                {
                    history.Actions = "EMAIL(C)"; 
                    subject = "AVISO CANCELACION";}
                break;
            default: { history.Actions = "EMAIL(AP)"; 
                       subject = "AVISO PAGO"; }
                break;
        }
        history.KeyID = taskControlID.ToString();
        history.Subject = "POLICIES";
        //history.BuildNotesForHistory("TaskControlID.", "", taskControlID.ToString(), 7);  //7 = mode NOTICEOFCANC
        history.UsersID = userID;
        history.Notes = "[EMAIL] " + subject + "\r\n";
        history.GetSaveHistory();
    }
}
   
}

