using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Application6 : System.Web.UI.Page
{
    private Control LeftMenu;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region Web Form Designer generated code
        Control Banner = new Control();
        Banner = LoadControl(@"TopBanner.ascx");
        //((Baldrich.BaldrichWeb.Components.TopBanner)Banner).SelectedOption = (int)Baldrich.HeadBanner.MenuOptions.Home;
        this.Placeholder1.Controls.Add(Banner);

        //Setup Left-side Banner

        LeftMenu = new Control();
        LeftMenu = LoadControl(@"LeftMenu.ascx");
        phTopBanner1.Controls.Add(LeftMenu);
        #endregion

        this.litPopUp.Visible = false;

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        if (cp == null)
        {
            Response.Redirect("Default.aspx?001");
        }
        else
        {
            if (!cp.IsInRole("APPLICATION") && !cp.IsInRole("ADMINISTRATOR"))
            {
                Response.Redirect("Default.aspx?001");
            }
        }


        if (Session["AutoPostBack"] == null)
        {
            if (!IsPostBack)
            {
                if (Session["TaskControl"] != null)
                {
                    EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

                    switch (taskControl.ApplicationMode)
                    {
                        case "ADD":
                            EnableControls();
                            FillTextControl();

                            //rdoMca62.Items[0].Selected = false;
                            //rdoMca63.Items[0].Selected = false;
                            //rdoMca64.Items[0].Selected = false;
                            //rdoMca65.Items[0].Selected = false;
                            //rdoMca66.Items[0].Selected = false;
                            //rdoMca67.Items[0].Selected = false;
                            //rdoMca68.Items[0].Selected = false;
                            //rdoMca69.Items[0].Selected = false;
                            //rdoMca70.Items[0].Selected = false;
                            //rdoMca71.Items[0].Selected = false;
                            //rdoMca72.Items[0].Selected = false;
                            //rdoMca73a.Items[0].Selected = false;
                            //rdoMca73b.Items[0].Selected = false;
                            //rdoMca73c.Items[0].Selected = false;
                            //rdoMca73d.Items[0].Selected = false;
                            //rdoMca73e.Items[0].Selected = false;
                            //rdoMca73f.Items[0].Selected = false;
                            break;

                        case "UPDATE":
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
                    EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];
                    if (taskControl.Mode == 4)
                    {
                        //DisableControls();
                    }
                }
            }
        }
        else
        {
            //FillTextControl();
            //EnableControls();
            Session.Remove("AutoPostBack");
        }

    }


    private void FillProperties()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        taskControl.Mca42kDesc = txtMca42kDesc.Text.ToUpper().Trim();
        taskControl.Mca42lDesc = txtMca42lDesc.Text.ToUpper().Trim();

        if (rdoMca42a.Items[0].Selected)
        {
            taskControl.Mca42a = true;
        }
        else
        {
            taskControl.Mca42a = false;
        }

        if (rdoMca42b.Items[0].Selected)
        {
            taskControl.Mca42b = true;
        }
        else
        {
            taskControl.Mca42b = false;
        }

        if (rdoMca42c.Items[0].Selected)
        {
            taskControl.Mca42c = true;
        }
        else
        {
            taskControl.Mca42c = false;
        }

        if (rdoMca42d.Items[0].Selected)
        {
            taskControl.Mca42d = true;
        }
        else
        {
            taskControl.Mca42d = false;
        }

        if (rdoMca42e.Items[0].Selected)
        {
            taskControl.Mca42e = true;
        }
        else
        {
            taskControl.Mca42e = false;
        }

        if (rdoMca42f.Items[0].Selected)
        {
            taskControl.Mca42f = true;
        }
        else
        {
            taskControl.Mca42f = false;
        }

        if (rdoMca42h.Items[0].Selected)
        {
            taskControl.Mca42h = true;
        }
        else
        {
            taskControl.Mca42h = false;
        }

        if (rdoMca42i.Items[0].Selected)
        {
            taskControl.Mca42i = true;
        }
        else
        {
            taskControl.Mca42i = false;
        }

        if (rdoMca42j.Items[0].Selected)
        {
            taskControl.Mca42j = true;
        }
        else
        {
            taskControl.Mca42j = false;
        }

        if (rdoMca42k.Items[0].Selected)
        {
            taskControl.Mca42k = true;
        }
        else
        {
            taskControl.Mca42k = false;
        }

        if (rdoMca42l.Items[0].Selected)
        {
            taskControl.Mca42l = true;
        }
        else
        {
            taskControl.Mca42l = false;
        }

        if (rdoMca44.Items[0].Selected)
        {
            taskControl.Mca44 = true;
        }
        else
        {
            taskControl.Mca44 = false;
        }

        if (rdoMca45.Items[0].Selected)
        {
            taskControl.Mca45 = true;
        }
        else
        {
            taskControl.Mca45 = false;
        }

        if (rdoMca46.Items[0].Selected)
        {
            taskControl.Mca46 = true;
        }
        else
        {
            taskControl.Mca46 = false;
        }

        if (rdoMca47.Items[0].Selected)
        {
            taskControl.Mca47 = true;
        }
        else
        {
            taskControl.Mca47 = false;
        }


        if (rdoMca47b.Items[0].Selected)
        {
            taskControl.Mca47b = true;
        }
        else
        {
            taskControl.Mca47b = false;
        }

        if (rdoMca48.Items[0].Selected)
        {
            taskControl.Mca48 = true;
        }
        else
        {
            taskControl.Mca48 = false;
        }

        if (rdoMca48b.Items[0].Selected)
        {
            taskControl.Mca48b = true;
        }
        else
        {
            taskControl.Mca48b = false;
        }

        if (rdoMca48c.Items[0].Selected)
        {
            taskControl.Mca48c = true;
        }
        else
        {
            taskControl.Mca48c = false;
        }

        if (rdoMca49.Items[0].Selected)
        {
            taskControl.Mca49 = true;
        }
        else
        {
            taskControl.Mca49 = false;
        }

        if (rdoMca50.Items[0].Selected)
        {
            taskControl.Mca50 = true;
        }
        else
        {
            taskControl.Mca50 = false;
        }

        if (rdoMca51.Items[0].Selected)
        {
            taskControl.Mca51 = true;
        }
        else
        {
            taskControl.Mca51 = false;
        }

        if (rdoMca52.Items[0].Selected)
        {
            taskControl.Mca52 = true;
        }
        else
        {
            taskControl.Mca52 = false;
        }

        if (rdoMca53.Items[0].Selected)
        {
            taskControl.Mca53 = true;
        }
        else
        {
            taskControl.Mca53 = false;
        }

        if (rdoMca54.Items[0].Selected)
        {
            taskControl.Mca54 = true;
        }
        else
        {
            taskControl.Mca54 = false;
        }

        if (rdoMca55.Items[0].Selected)
        {
            taskControl.Mca55 = true;
        }
        else
        {
            taskControl.Mca55 = false;
        }

        if (rdoMca56.Items[0].Selected)
        {
            taskControl.Mca56 = true;
        }
        else
        {
            taskControl.Mca56 = false;
        }


        if (rdoMca56First.Items[0].Selected)
        {
            taskControl.Mca56First = true;
        }
        else
        {
            taskControl.Mca56First = false;
        }

        if (Mca56Second.Items[0].Selected)
        {
            taskControl.Mca56Second = true;
        }
        else
        {
            taskControl.Mca56Second = false;
        }

        if (rdoMca56third.Items[0].Selected)
        {
            taskControl.Mca56Third = true;
        }
        else
        {
            taskControl.Mca56Third = false;
        }

        if (rdoMca57.Items[0].Selected)
        {
            taskControl.Mca57 = true;
        }
        else
        {
            taskControl.Mca57 = false;
        }

        if (rdoMca58.Items[0].Selected)
        {
            taskControl.Mca58 = true;
        }
        else
        {
            taskControl.Mca58 = false;
        }

        if (rdoMca59.Items[0].Selected)
        {
            taskControl.Mca59 = true;
        }
        else
        {
            taskControl.Mca59 = false;
        }

        if (rdoMca60.Items[0].Selected)
        {
            taskControl.Mca60 = true;
        }
        else
        {
            taskControl.Mca60 = false;
        }

        if (rdoMca61.Items[0].Selected)
        {
            taskControl.Mca61 = true;
        }
        else
        {
            taskControl.Mca61 = false;
        }

        taskControl.McaAbort = chkMcaAbort.Checked;
        taskControl.McaAnes = chkMcaAnes.Checked;
        taskControl.McaCardio = chkMcaCardio.Checked;
        taskControl.McaChymo = chkMcaChymo.Checked;
        taskControl.McaColon = chkMcaColon.Checked;
        taskControl.McaGen = chkMcaGen.Checked;
        taskControl.McaGyne = chkMcaGyne.Checked;
        taskControl.McaHand = chkMcaHand.Checked;
        taskControl.McaHead = chkMcaHead.Checked;
        taskControl.McaLapa = chkMcaLapa.Checked;
        taskControl.App6mcaOther = chkMcaOther.Checked;
        taskControl.App6mcaLipo = chkMcaLipo.Checked;
        taskControl.McaNeuro = chkMcaNeuro.Checked;
        taskControl.McaObs = chkMcaObs.Checked;
        taskControl.McaOph = chkMcaOph.Checked;
        taskControl.McaOrth = chkMcaOrth.Checked;
        taskControl.McaOrthoReplace = chkMcaOrthoReplace.Checked;
        taskControl.McaPlaSurElective = chkMcaPlaSurElective.Checked;
        taskControl.McaRefra = chkMcaRefra.Checked;
        taskControl.McaSpinLumbar = chkMcaSpinLumbar.Checked;
        taskControl.McaSpinOther = chkMcaSpinOther.Checked;
        taskControl.McaThora = chkMcaThora.Checked;
        taskControl.McaUro = chkMcaUro.Checked;
        taskControl.McaVas = chkMcaVas.Checked;

        taskControl.AbortYear = txtAbortYear.Text.ToUpper().Trim();
        taskControl.AnesYear = txtAnesYear.Text.ToUpper().Trim();
        taskControl.CardioYear = txtCardioYear.Text.ToUpper().Trim();
        taskControl.ChymoYear = txtChymoYear.Text.ToUpper().Trim();
        taskControl.ColonYear = txtColonYear.Text.ToUpper().Trim();
        taskControl.GenYear = txtGenYear.Text.ToUpper().Trim();
        taskControl.GyneYear = txtGyneYear.Text.ToUpper().Trim();
        taskControl.HandYear = txtHandYear.Text.ToUpper().Trim();
        taskControl.HeadYear = txtHeadYear.Text.ToUpper().Trim();
        taskControl.LapaYear = txtLapaYear.Text.ToUpper().Trim();
        taskControl.OtherYear = txtOtherYear.Text.ToUpper().Trim();
        taskControl.LipoYear = txtLipoYear.Text.ToUpper().Trim();
        taskControl.NeuroYear = txtNeuroYear.Text.ToUpper().Trim();
        taskControl.ObsYear = txtObsYear.Text.ToUpper().Trim();
        taskControl.OphYear = txtOphYear.Text.ToUpper().Trim();
        taskControl.OrthYear = txtOrthYear.Text.ToUpper().Trim();
        taskControl.OrthoReplaceYear = txtOrthoReplaceYear.Text.ToUpper().Trim();
        taskControl.PlaSurElectiveYear = txtPlaSurElectiveYear.Text.ToUpper().Trim();
        taskControl.RefraYear = txtRefraYear.Text.ToUpper().Trim();
        taskControl.SpinLumbarYear = txtSpinLumbarYear.Text.ToUpper().Trim();
        taskControl.SpinOtherYear = txtSpinOtherYear.Text.ToUpper().Trim();
        taskControl.ThoraYear = txtThoraYear.Text.ToUpper().Trim();
        taskControl.UroYear = txtUroYear.Text.ToUpper().Trim();
        taskControl.VasYear = txtVasYear.Text.ToUpper().Trim();

        taskControl.AbortPercent = txtAbortPercent.Text.ToUpper().Trim();
        taskControl.AnesPercent = txtAnesPercent.Text.ToUpper().Trim();
        taskControl.CardioPercent = txtCardioPercent.Text.ToUpper().Trim();
        taskControl.ChymoPercent = txtChymoPercent.Text.ToUpper().Trim();
        taskControl.ColonPercent = txtColonPercent.Text.ToUpper().Trim();
        taskControl.GenPercent = txtGenPercent.Text.ToUpper().Trim();
        taskControl.GynePercent = txtGynePercent.Text.ToUpper().Trim();
        taskControl.HandPercent = txtHandPercent.Text.ToUpper().Trim();
        taskControl.HeadPercent = txtHeadPercent.Text.ToUpper().Trim();
        taskControl.LapaPercent = txtLapaPercent.Text.ToUpper().Trim();
        taskControl.OtherPercent = txtOtherPercent.Text.ToUpper().Trim();
        taskControl.LipoPercent = txtLipoPercent.Text.ToUpper().Trim();
        taskControl.NeuroPercent = txtNeuroPercent.Text.ToUpper().Trim();
        taskControl.ObsPercent = txtObsPercent.Text.ToUpper().Trim();
        taskControl.OphPercent = txtOphPercent.Text.ToUpper().Trim();
        taskControl.OrthPercent = txtOrthPercent.Text.ToUpper().Trim();
        taskControl.OrthoReplacePercent = txtOrthoReplacePercent.Text.ToUpper().Trim();
        taskControl.PlaSurElectivePercent = txtPlaSurElectivePercent.Text.ToUpper().Trim();
        taskControl.RefraPercent = txtRefraPercent.Text.ToUpper().Trim();
        taskControl.SpinLumbarPercent = txtSpinLumbarPercent.Text.ToUpper().Trim();
        taskControl.SpinOtherPercent = txtSpinOtherPercent.Text.ToUpper().Trim();
        taskControl.ThoraPercent = txtThoraPercent.Text.ToUpper().Trim();
        taskControl.UroPercent = txtUroPercent.Text.ToUpper().Trim();
        taskControl.VasPercent = txtVasPercent.Text.ToUpper().Trim();

        taskControl.App643Desc = txtapp643Desc.Text.ToUpper().Trim();
        taskControl.App644Desc = txtapp644Desc.Text.ToUpper().Trim();
        taskControl.App647Inst = txtapp647Inst.Text.ToUpper().Trim();
        taskControl.App647Addr = txtapp647Addr.Text.ToUpper().Trim();
        taskControl.App647bPercent = txtapp647bPercent.Text.ToUpper().Trim();
        taskControl.App648Ent = txtapp648Ent.Text.ToUpper().Trim();
        taskControl.App648Addr = txtapp648Addr.Text.ToUpper().Trim();
        taskControl.App649Desc = txtapp649Desc.Text.ToUpper().Trim();
        taskControl.App650Desc = txtapp650Desc.Text.ToUpper().Trim();
        taskControl.App657DescB = txtapp657DescB.Text.ToUpper().Trim();
        taskControl.App654b = txtapp654b.Text.ToUpper().Trim();
        taskControl.App654c = txtapp654c.Text.ToUpper().Trim();
        taskControl.App654d = txtapp654d.Text.ToUpper().Trim();
        taskControl.App655Desc = txtapp655Desc.Text.ToUpper().Trim();
        taskControl.Desc56A = txtDesc56A.Text.ToUpper().Trim();
        taskControl.Desc56B = txtDesc56B.Text.ToUpper().Trim();
        taskControl.Desc56C = txtDesc56C.Text.ToUpper().Trim();
        taskControl.App657DescA = txtapp657DescA.Text.ToUpper().Trim();
        taskControl.App658DescA = txtapp658DescA.Text.ToUpper().Trim();
        taskControl.Mca42g = txtMca42g.Text.ToUpper().Trim(); 

        //rdoMca55b.Enabled = true;//Falta implementar este campo camniarlo por mcaortho;  
        if (rdoMca55b.Items[0].Selected)
        {
            taskControl.McaOrtho = true;
        }
        else
        {
            taskControl.McaOrtho = false;
        }

    }

    private void FillTextControl()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        lblTaskControlID.Text = taskControl.TaskControlID.ToString();
        txtMca42kDesc.Text = taskControl.Mca42kDesc ;
        txtMca42lDesc.Text = taskControl.Mca42lDesc;

        if (taskControl.Mca42a)
        {
            rdoMca42a.Items[0].Selected = true;
            rdoMca42a.Items[1].Selected = false;
        }
        else
        {
            rdoMca42a.Items[0].Selected = false;
            rdoMca42a.Items[1].Selected = true;
        }

        if (taskControl.Mca42b)
        {
            rdoMca42b.Items[0].Selected = true;
            rdoMca42b.Items[1].Selected = false;
        }
        else
        {
            rdoMca42b.Items[0].Selected = false;
            rdoMca42b.Items[1].Selected = true;
        }

        if (taskControl.Mca42c)
        {
            rdoMca42c.Items[0].Selected = true;
            rdoMca42c.Items[1].Selected = false;
        }
        else
        {
            rdoMca42c.Items[0].Selected = false;
            rdoMca42c.Items[1].Selected = true;
        }

        if (taskControl.Mca42d)
        {
            rdoMca42d.Items[0].Selected = true;
            rdoMca42d.Items[1].Selected = false;
        }
        else
        {
            rdoMca42d.Items[0].Selected = false;
            rdoMca42d.Items[1].Selected = true;
        }

        if (taskControl.Mca42e)
        {
            rdoMca42e.Items[0].Selected = true;
            rdoMca42e.Items[1].Selected = false;
        }
        else
        {
            rdoMca42e.Items[0].Selected = false;
            rdoMca42e.Items[1].Selected = true;
        }


        if (taskControl.Mca42f)
        {
            rdoMca42f.Items[0].Selected = true;
            rdoMca42f.Items[1].Selected = false;
        }
        else
        {
            rdoMca42f.Items[0].Selected = false;
            rdoMca42f.Items[1].Selected = true;
        }

        if (taskControl.Mca42h)
        {
            rdoMca42h.Items[0].Selected = true;
            rdoMca42h.Items[1].Selected = false;
        }
        else
        {
            rdoMca42h.Items[0].Selected = false;
            rdoMca42h.Items[1].Selected = true;
        }

        if (taskControl.Mca42i)
        {
            rdoMca42i.Items[0].Selected = true;
            rdoMca42i.Items[1].Selected = false;
        }
        else
        {
            rdoMca42i.Items[0].Selected = false;
            rdoMca42i.Items[1].Selected = true;
        }

        if (taskControl.Mca42j)
        {
            rdoMca42j.Items[0].Selected = true;
            rdoMca42j.Items[1].Selected = false;
        }
        else
        {
            rdoMca42j.Items[0].Selected = false;
            rdoMca42j.Items[1].Selected = true;
        }

        if (taskControl.Mca42k)
        {
            rdoMca42k.Items[0].Selected = true;
            rdoMca42k.Items[1].Selected = false;
        }
        else
        {
            rdoMca42k.Items[0].Selected = false;
            rdoMca42k.Items[1].Selected = true;
        }

        if (taskControl.Mca42l)
        {
            rdoMca42l.Items[0].Selected = true;
            rdoMca42l.Items[1].Selected = false;
        }
        else
        {
            rdoMca42l.Items[0].Selected = false;
            rdoMca42l.Items[1].Selected = true;
        }

        if (taskControl.Mca44)
        {
            rdoMca44.Items[0].Selected = true;
            rdoMca44.Items[1].Selected = false;
        }
        else
        {
            rdoMca44.Items[0].Selected = false;
            rdoMca44.Items[1].Selected = true;
        }

        if (taskControl.Mca45)
        {
            rdoMca45.Items[0].Selected = true;
            rdoMca45.Items[1].Selected = false;
        }
        else
        {
            rdoMca45.Items[0].Selected = false;
            rdoMca45.Items[1].Selected = true;
        }

        if (taskControl.Mca46)
        {
            rdoMca46.Items[0].Selected = true;
            rdoMca46.Items[1].Selected = false;
        }
        else
        {
            rdoMca46.Items[0].Selected = false;
            rdoMca46.Items[1].Selected = true;
        }

        if (taskControl.Mca47)
        {
            rdoMca47.Items[0].Selected = true;
            rdoMca47.Items[1].Selected = false;
        }
        else
        {
            rdoMca47.Items[0].Selected = false;
            rdoMca47.Items[1].Selected = true;
        }

        if (taskControl.Mca47b)
        {
            rdoMca47b.Items[0].Selected = true;
            rdoMca47b.Items[1].Selected = false;
        }
        else
        {
            rdoMca47b.Items[0].Selected = false;
            rdoMca47b.Items[1].Selected = true;
        }

        if (taskControl.Mca48)
        {
            rdoMca48.Items[0].Selected = true;
            rdoMca48.Items[1].Selected = false;
        }
        else
        {
            rdoMca48.Items[0].Selected = false;
            rdoMca48.Items[1].Selected = true;
        }

        if (taskControl.Mca48b)
        {
            rdoMca48b.Items[0].Selected = true;
            rdoMca48b.Items[1].Selected = false;
        }
        else
        {
            rdoMca48b.Items[0].Selected = false;
            rdoMca48b.Items[1].Selected = true;
        }

        if (taskControl.Mca48c)
        {
            rdoMca48c.Items[0].Selected = true;
            rdoMca48c.Items[1].Selected = false;
        }
        else
        {
            rdoMca48c.Items[0].Selected = false;
            rdoMca48c.Items[1].Selected = true;
        }

        if (taskControl.Mca49)
        {
            rdoMca49.Items[0].Selected = true;
            rdoMca49.Items[1].Selected = false;
        }
        else
        {
            rdoMca49.Items[0].Selected = false;
            rdoMca49.Items[1].Selected = true;
        }

        if (taskControl.Mca50)
        {
            rdoMca50.Items[0].Selected = true;
            rdoMca50.Items[1].Selected = false;
        }
        else
        {
            rdoMca50.Items[0].Selected = false;
            rdoMca50.Items[1].Selected = true;
        }

        if (taskControl.Mca51)
        {
            rdoMca51.Items[0].Selected = true;
            rdoMca51.Items[1].Selected = false;
        }
        else
        {
            rdoMca51.Items[0].Selected = false;
            rdoMca51.Items[1].Selected = true;
        }

        if (taskControl.Mca52)
        {
            rdoMca52.Items[0].Selected = true;
            rdoMca52.Items[1].Selected = false;
        }
        else
        {
            rdoMca52.Items[0].Selected = false;
            rdoMca52.Items[1].Selected = true;
        }

        if (taskControl.Mca53)
        {
            rdoMca53.Items[0].Selected = true;
            rdoMca53.Items[1].Selected = false;
        }
        else
        {
            rdoMca53.Items[0].Selected = false;
            rdoMca53.Items[1].Selected = true;
        }

        if (taskControl.Mca54)
        {
            rdoMca54.Items[0].Selected = true;
            rdoMca54.Items[1].Selected = false;
        }
        else
        {
            rdoMca54.Items[0].Selected = false;
            rdoMca54.Items[1].Selected = true;
        }

        if (taskControl.Mca55)
        {
            rdoMca55.Items[0].Selected = true;
            rdoMca55.Items[1].Selected = false;
        }
        else
        {
            rdoMca55.Items[0].Selected = false;
            rdoMca55.Items[1].Selected = true;
        }

        if (taskControl.McaOrtho) //hace referencia al rdoMca55b
        {
            rdoMca55b.Items[0].Selected = true;
            rdoMca55b.Items[1].Selected = false;
        }
        else
        {
            rdoMca55b.Items[0].Selected = false;
            rdoMca55b.Items[1].Selected = true;
        }

        if (taskControl.Mca56)
        {
            rdoMca56.Items[0].Selected = true;
            rdoMca56.Items[1].Selected = false;
        }
        else
        {
            rdoMca56.Items[0].Selected = false;
            rdoMca56.Items[1].Selected = true;
        }

        if (taskControl.Mca56First)
        {
            rdoMca56First.Items[0].Selected = true;
            rdoMca56First.Items[1].Selected = false;
        }
        else
        {
            rdoMca56First.Items[0].Selected = false;
            rdoMca56First.Items[1].Selected = true;
        }

        if (taskControl.Mca56Second)
        {
            Mca56Second.Items[0].Selected = true;
            Mca56Second.Items[1].Selected = false;
        }
        else
        {
            Mca56Second.Items[0].Selected = false;
            Mca56Second.Items[1].Selected = true;
        }

        if (taskControl.Mca56Third)
        {
            rdoMca56third.Items[0].Selected = true;
            rdoMca56third.Items[1].Selected = false;
        }
        else
        {
            rdoMca56third.Items[0].Selected = false;
            rdoMca56third.Items[1].Selected = true;
        }

        if (taskControl.Mca57)
        {
            rdoMca57.Items[0].Selected = true;
            rdoMca57.Items[1].Selected = false;
        }
        else
        {
            rdoMca57.Items[0].Selected = false;
            rdoMca57.Items[1].Selected = true;
        }

        if (taskControl.Mca58)
        {
            rdoMca58.Items[0].Selected = true;
            rdoMca58.Items[1].Selected = false;
        }
        else
        {
            rdoMca58.Items[0].Selected = false;
            rdoMca58.Items[1].Selected = true;
        }

        if (taskControl.Mca58)
        {
            rdoMca59.Items[0].Selected = true;
            rdoMca59.Items[1].Selected = false;
        }
        else
        {
            rdoMca59.Items[0].Selected = false;
            rdoMca59.Items[1].Selected = true;
        }

        if (taskControl.Mca60)
        {
            rdoMca60.Items[0].Selected = true;
            rdoMca60.Items[1].Selected = false;
        }
        else
        {
            rdoMca60.Items[0].Selected = false;
            rdoMca60.Items[1].Selected = true;
        }

        if (taskControl.Mca61)
        {
            rdoMca61.Items[0].Selected = true;
            rdoMca61.Items[1].Selected = false;
        }
        else
        {
            rdoMca61.Items[0].Selected = false;
            rdoMca61.Items[1].Selected = true;
        }

        chkMcaAbort.Checked = taskControl.McaAbort;
        chkMcaAnes.Checked = taskControl.McaAnes;
        chkMcaCardio.Checked = taskControl.McaCardio;
        chkMcaChymo.Checked = taskControl.McaChymo;
        chkMcaColon.Checked = taskControl.McaColon;
        chkMcaGen.Checked = taskControl.McaGen;
        chkMcaGyne.Checked = taskControl.McaGyne;
        chkMcaHand.Checked = taskControl.McaHand;
        chkMcaHead.Checked = taskControl.McaHead;
        chkMcaLapa.Checked = taskControl.McaLapa;
        chkMcaOther.Checked = taskControl.App6mcaOther;
        chkMcaLipo.Checked = taskControl.App6mcaLipo;
        chkMcaNeuro.Checked = taskControl.McaNeuro;
        chkMcaObs.Checked = taskControl.McaObs;
        chkMcaOph.Checked = taskControl.McaOph;
        chkMcaOrth.Checked = taskControl.McaOrth;
        chkMcaOrthoReplace.Checked = taskControl.McaOrthoReplace;
        chkMcaPlaSurElective.Checked = taskControl.McaPlaSurElective;
        chkMcaRefra.Checked = taskControl.McaRefra;
        chkMcaSpinLumbar.Checked = taskControl.McaSpinLumbar;
        chkMcaSpinOther.Checked = taskControl.McaSpinOther;
        chkMcaThora.Checked = taskControl.McaThora;
        chkMcaUro.Checked = taskControl.McaUro;
        chkMcaVas.Checked = taskControl.McaVas;

        txtAbortYear.Text = taskControl.AbortYear;
        txtAnesYear.Text = taskControl.AnesYear;
        txtCardioYear.Text = taskControl.CardioYear;
        txtChymoYear.Text = taskControl.ChymoYear;
        txtColonYear.Text = taskControl.ColonYear;
        txtGenYear.Text = taskControl.GenYear;
        txtGyneYear.Text = taskControl.GyneYear;
        txtHandYear.Text = taskControl.HandYear;
        txtHeadYear.Text = taskControl.HeadYear;
        txtLapaYear.Text = taskControl.LapaYear;
        txtOtherYear.Text = taskControl.OtherYear;
        txtLipoYear.Text = taskControl.LipoYear;
        txtNeuroYear.Text = taskControl.NeuroPercent;
        txtObsYear.Text = taskControl.ObsYear;
        txtOphYear.Text = taskControl.OphYear;
        txtOrthYear.Text = taskControl.OrthYear;
        txtOrthoReplaceYear.Text = taskControl.OrthoReplaceYear;
        txtPlaSurElectiveYear.Text = taskControl.PlaSurElectiveYear;
        txtRefraYear.Text = taskControl.RefraYear;
        txtSpinLumbarYear.Text = taskControl.SpinLumbarPercent;
        txtSpinOtherYear.Text = taskControl.SpinOtherYear;
        txtThoraYear.Text = taskControl.ThoraYear;
        txtUroYear.Text = taskControl.UroYear;
        txtVasYear.Text = taskControl.VasYear;

        txtAbortPercent.Text = taskControl.AbortPercent;
        txtAnesPercent.Text = taskControl.AnesPercent;
        txtCardioPercent.Text = taskControl.CardioPercent;
        txtChymoPercent.Text = taskControl.ChymoPercent;
        txtColonPercent.Text = taskControl.ColonPercent;
        txtGenPercent.Text = taskControl.GenPercent;
        txtGynePercent.Text = taskControl.GynePercent;
        txtHandPercent.Text = taskControl.HandPercent;
        txtHeadPercent.Text = taskControl.HeadPercent;
        txtLapaPercent.Text = taskControl.LapaPercent;
        txtOtherPercent.Text = taskControl.OtherPercent;
        txtLipoPercent.Text = taskControl.LipoPercent;
        txtNeuroPercent.Text = taskControl.NeuroPercent;
        txtObsPercent.Text = taskControl.ObsPercent;
        txtOphPercent.Text =  taskControl.OphPercent;
        txtOrthPercent.Text = taskControl.OrthPercent;
        txtOrthoReplacePercent.Text = taskControl.OrthoReplacePercent;
        txtPlaSurElectivePercent.Text = taskControl.PlaSurElectivePercent;
        txtRefraPercent.Text = taskControl.RefraPercent;
        txtSpinLumbarPercent.Text = taskControl.SpinLumbarPercent;
        txtSpinOtherPercent.Text = taskControl.SpinOtherPercent;
        txtThoraPercent.Text = taskControl.ThoraPercent;
        txtUroPercent.Text = taskControl.UroPercent;
        txtVasPercent.Text = taskControl.VasPercent;

        txtapp643Desc.Text = taskControl.App643Desc;
        txtapp644Desc.Text = taskControl.App644Desc;
        txtapp647Inst.Text = taskControl.App647Inst;
        txtapp647Addr.Text = taskControl.App647Addr;
        txtapp647bPercent.Text = taskControl.App647bPercent;
        txtapp648Ent.Text = taskControl.App648Ent;
        txtapp648Addr.Text = taskControl.App648Addr;
        txtapp649Desc.Text = taskControl.App649Desc;
        txtapp650Desc.Text = taskControl.App650Desc;
        txtapp657DescB.Text = taskControl.App657DescB;
        txtapp654b.Text = taskControl.App654b;
        txtapp654c.Text = taskControl.App654c;
        txtapp654d.Text = taskControl.App654d;
        txtapp655Desc.Text = taskControl.App655Desc;
        txtDesc56A.Text = taskControl.Desc56A;
        txtDesc56B.Text = taskControl.Desc56B;
        txtDesc56C.Text = taskControl.Desc56C;
        txtapp657DescA.Text = taskControl.App657DescA;
        txtapp658DescA.Text = taskControl.App658DescA;
        txtMca42g.Text = taskControl.Mca42g; 

    }

    private void Save()
    {
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
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

        try
        {
            ValidateFields();

            FillProperties();
            EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

            taskControl.Save(userID, 6);  //(userID);
            FillTextControl();
            DisableControls();

            Session["TaskControl"] = taskControl;

            if (taskControl.ApplicationMode == "UPDATE" || taskControl.ApplicationMode == "ADD")
            {
                if (taskControl.ApplicationExist(taskControl.TaskControlID, 6))
                    taskControl.ApplicationMode = "UPDATE";
                else
                    taskControl.ApplicationMode = "ADD";
            }
            else
            {
                if (taskControl.ApplicationExist(taskControl.TaskControlID, 6))
                    taskControl.ApplicationMode = "";
                else
                    taskControl.ApplicationMode = "ADD";
            }

            Response.Redirect("Application7.aspx", false);
            //this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Information saved successfully.");
            //this.litPopUp.Visible = true;
        }
        catch (Exception exp)
        {
            this.litPopUp.Text = EPolicy.Utilities.MakeLiteralPopUpString("Unable to save this Information. " + exp.Message);
            this.litPopUp.Visible = true;
        }
    }

    private void EnableControls()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        btnNextBottom.Visible = true;
        btnPrevBottom.Visible = true;
        btnNextTop.Enabled = true;
        btnNextBottom.Enabled = true;

        chkMcaAbort.Enabled = true;
        chkMcaAnes.Enabled = true;
        chkMcaCardio.Enabled = true;
        chkMcaChymo.Enabled = true;
        chkMcaColon.Enabled = true;
        chkMcaGen.Enabled = true;
        chkMcaGyne.Enabled = true;
        chkMcaHand.Enabled = true;
        chkMcaHead.Enabled = true;
        chkMcaLapa.Enabled = true;
        chkMcaOther.Enabled = true;
        chkMcaLipo.Enabled = true;
        chkMcaNeuro.Enabled = true;
        chkMcaObs.Enabled = true;
        chkMcaOph.Enabled = true;
        chkMcaOrth.Enabled = true;
        chkMcaOrthoReplace.Enabled = true;
        chkMcaPlaSurElective.Enabled = true;
        chkMcaRefra.Enabled = true;
        chkMcaSpinLumbar.Enabled = true;
        chkMcaSpinOther.Enabled = true;
        chkMcaThora.Enabled = true;
        chkMcaUro.Enabled = true;
        chkMcaVas.Enabled = true;

        txtAbortYear.Enabled = true;
        txtAnesYear.Enabled = true;
        txtCardioYear.Enabled = true;
        txtChymoYear.Enabled = true;
        txtColonYear.Enabled = true;
        txtGenYear.Enabled = true;
        txtGyneYear.Enabled = true;
        txtHandYear.Enabled = true;
        txtHeadYear.Enabled = true;
        txtLapaYear.Enabled = true;
        txtOtherYear.Enabled = true;
        txtLipoYear.Enabled = true;
        txtNeuroYear.Enabled = true;
        txtObsYear.Enabled = true;
        txtOphYear.Enabled = true;
        txtOrthYear.Enabled = true;
        txtOrthoReplaceYear.Enabled = true;
        txtPlaSurElectiveYear.Enabled = true;
        txtRefraYear.Enabled = true;
        txtSpinLumbarYear.Enabled = true;
        txtSpinOtherYear.Enabled = true;
        txtThoraYear.Enabled = true;
        txtUroYear.Enabled = true;
        txtVasYear.Enabled = true;

        txtAbortPercent.Enabled = true;
        txtAnesPercent.Enabled = true;
        txtCardioPercent.Enabled = true;
        txtChymoPercent.Enabled = true;
        txtColonPercent.Enabled = true;
        txtGenPercent.Enabled = true;
        txtGynePercent.Enabled = true;
        txtHandPercent.Enabled = true;
        txtHeadPercent.Enabled = true;
        txtLapaPercent.Enabled = true;
        txtOtherPercent.Enabled = true;
        txtLipoPercent.Enabled = true;
        txtNeuroPercent.Enabled = true;
        txtObsPercent.Enabled = true;
        txtOphPercent.Enabled = true;
        txtOrthPercent.Enabled = true;
        txtOrthoReplacePercent.Enabled = true;
        txtPlaSurElectivePercent.Enabled = true;
        txtRefraPercent.Enabled = true;
        txtSpinLumbarPercent.Enabled = true;
        txtSpinOtherPercent.Enabled = true;
        txtThoraPercent.Enabled = true;
        txtUroPercent.Enabled = true;
        txtVasPercent.Enabled = true;

        rdoMca42a.Enabled = true;
        rdoMca42b.Enabled = true;
        rdoMca42c.Enabled = true;
        rdoMca42d.Enabled = true;
        rdoMca42e.Enabled = true;
        rdoMca42f.Enabled = true;
        txtMca42g.Enabled = true;
        rdoMca42h.Enabled = true;
        rdoMca42i.Enabled = true;
        rdoMca42j.Enabled = true;
        rdoMca42k.Enabled = true;
        txtMca42kDesc.Enabled = true;
        rdoMca42l.Enabled = true;
        txtMca42lDesc.Enabled = true;

        txtapp643Desc.Enabled = true;
        rdoMca44.Enabled = true;
        txtapp644Desc.Enabled = true;
        rdoMca45.Enabled = true;
        rdoMca46.Enabled = true;
        rdoMca47.Enabled = true;
        txtapp647Inst.Enabled = true;
        txtapp647Addr.Enabled = true;
        rdoMca47b.Enabled = true;
        txtapp647bPercent.Enabled = true;
        rdoMca48.Enabled = true;
        txtapp648Ent.Enabled = true;
        txtapp648Addr.Enabled = true;
        rdoMca48b.Enabled = true;
        rdoMca48c.Enabled = true;
        rdoMca49.Enabled = true;
        txtapp649Desc.Enabled = true;
        rdoMca50.Enabled = true;
        txtapp650Desc.Enabled = true;
        rdoMca51.Enabled = true;
        rdoMca52.Enabled = true;
        txtapp657DescB.Enabled = true;
        rdoMca53.Enabled = true;
        rdoMca54.Enabled = true;
        txtapp654b.Enabled = true;
        txtapp654c.Enabled = true;
        txtapp654d.Enabled = true;
        rdoMca55.Enabled = true;
        txtapp655Desc.Enabled = true;
        rdoMca55b.Enabled = true;//Falta implementar este campo
        rdoMca56.Enabled = true;
        rdoMca56First.Enabled = true;
        Mca56Second.Enabled = true;
        rdoMca56third.Enabled = true;
        txtDesc56A.Enabled = true;
        txtDesc56B.Enabled = true;
        txtDesc56C.Enabled = true;
        rdoMca57.Enabled = true;
        txtapp657DescA.Enabled = true;
        rdoMca58.Enabled = true;
        txtapp658DescA.Enabled = true;
        rdoMca59.Enabled = true;
        rdoMca60.Enabled = true;
        rdoMca61.Enabled = true;



    }

    private void DisableControls()
    {
        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        btnNextTop.Visible = true;
        btnPrevBottom.Visible = true;
        btnNextTop.Enabled = true;
        btnNextBottom.Enabled = true;

        chkMcaAbort.Enabled = false;
        chkMcaAnes.Enabled = false;
        chkMcaCardio.Enabled = false;
        chkMcaChymo.Enabled = false;
        chkMcaColon.Enabled = false;
        chkMcaGen.Enabled = false;
        chkMcaGyne.Enabled = false;
        chkMcaHand.Enabled = false;
        chkMcaHead.Enabled = false;
        chkMcaLapa.Enabled = false;
        chkMcaOther.Enabled = false;
        chkMcaLipo.Enabled = false;
        chkMcaNeuro.Enabled = false;
        chkMcaObs.Enabled = false;
        chkMcaOph.Enabled = false;
        chkMcaOrth.Enabled = false;
        chkMcaOrthoReplace.Enabled = false;
        chkMcaPlaSurElective.Enabled = false;
        chkMcaRefra.Enabled = false;
        chkMcaSpinLumbar.Enabled = false;
        chkMcaSpinOther.Enabled = false;
        chkMcaThora.Enabled = false;
        chkMcaUro.Enabled = false;
        chkMcaVas.Enabled = false;

        txtAbortYear.Enabled = false;
        txtAnesYear.Enabled = false;
        txtCardioYear.Enabled = false;
        txtChymoYear.Enabled = false;
        txtColonYear.Enabled = false;
        txtGenYear.Enabled = false;
        txtGyneYear.Enabled = false;
        txtHandYear.Enabled = false;
        txtHeadYear.Enabled = false;
        txtLapaYear.Enabled = false;
        txtOtherYear.Enabled = false;
        txtLipoYear.Enabled = false;
        txtNeuroYear.Enabled = false;
        txtObsYear.Enabled = false;
        txtOphYear.Enabled = false;
        txtOrthYear.Enabled = false;
        txtOrthoReplaceYear.Enabled = false;
        txtPlaSurElectiveYear.Enabled = false;
        txtRefraYear.Enabled = false;
        txtSpinLumbarYear.Enabled = false;
        txtSpinOtherYear.Enabled = false;
        txtThoraYear.Enabled = false;
        txtUroYear.Enabled = false;
        txtVasYear.Enabled = false;

        txtAbortPercent.Enabled = false;
        txtAnesPercent.Enabled = false;
        txtCardioPercent.Enabled = false;
        txtChymoPercent.Enabled = false;
        txtColonPercent.Enabled = false;
        txtGenPercent.Enabled = false;
        txtGynePercent.Enabled = false;
        txtHandPercent.Enabled = false;
        txtHeadPercent.Enabled = false;
        txtLapaPercent.Enabled = false;
        txtOtherPercent.Enabled = false;
        txtLipoPercent.Enabled = false;
        txtNeuroPercent.Enabled = false;
        txtObsPercent.Enabled = false;
        txtOphPercent.Enabled = false;
        txtOrthPercent.Enabled = false;
        txtOrthoReplacePercent.Enabled = false;
        txtPlaSurElectivePercent.Enabled = false;
        txtRefraPercent.Enabled = false;
        txtSpinLumbarPercent.Enabled = false;
        txtSpinOtherPercent.Enabled = false;
        txtThoraPercent.Enabled = false;
        txtUroPercent.Enabled = false;
        txtVasPercent.Enabled = false;

        rdoMca42a.Enabled = false;
        rdoMca42b.Enabled = false;
        rdoMca42c.Enabled = false;
        rdoMca42d.Enabled = false;
        rdoMca42e.Enabled = false;
        rdoMca42f.Enabled = false;
        txtMca42g.Enabled = false;
        rdoMca42h.Enabled = false;
        rdoMca42i.Enabled = false;
        rdoMca42j.Enabled = false;
        rdoMca42k.Enabled = false;
        txtMca42kDesc.Enabled = false;
        rdoMca42l.Enabled = false;
        txtMca42lDesc.Enabled = false;

        txtapp643Desc.Enabled = false;
        rdoMca44.Enabled = false;
        txtapp644Desc.Enabled = false;
        rdoMca45.Enabled = false;
        rdoMca46.Enabled = false;
        rdoMca47.Enabled = false;
        txtapp647Inst.Enabled = false;
        txtapp647Addr.Enabled = false;
        rdoMca47b.Enabled = false;
        txtapp647bPercent.Enabled = false;
        rdoMca48.Enabled = false;
        txtapp648Ent.Enabled = false;
        txtapp648Addr.Enabled = false;
        rdoMca48b.Enabled = false;
        rdoMca48c.Enabled = false;
        rdoMca49.Enabled = false;
        txtapp649Desc.Enabled = false;
        rdoMca50.Enabled = false;
        txtapp650Desc.Enabled = false;
        rdoMca51.Enabled = false;
        rdoMca52.Enabled = false;
        txtapp657DescB.Enabled = false;
        rdoMca53.Enabled = false;
        rdoMca54.Enabled = false;
        txtapp654b.Enabled = false;
        txtapp654c.Enabled = false;
        txtapp654d.Enabled = false;
        rdoMca55.Enabled = false;
        txtapp655Desc.Enabled = false;
        rdoMca55b.Enabled = false;//Falta implementar este campo
        rdoMca56.Enabled = false;
        rdoMca56First.Enabled = false;
        Mca56Second.Enabled = false;
        rdoMca56third.Enabled = false;
        txtDesc56A.Enabled = false;
        txtDesc56B.Enabled = false;
        txtDesc56C.Enabled = false;
        rdoMca57.Enabled = false;
        txtapp657DescA.Enabled = false;
        rdoMca58.Enabled = false;
        txtapp658DescA.Enabled = false;
        rdoMca59.Enabled = false;
        rdoMca60.Enabled = false;
        rdoMca61.Enabled = false;



    }

    #region VerifyAccess
    private void VerifyAccess()
    {
        //TaskControl.Policies taskControl = (TaskControl.Policies)Session["TaskControl"];

        //Login.Login cp = HttpContext.Current.User as Login.Login;

        //if (!cp.IsInRole("BTNEDITPOLICIES") && !cp.IsInRole("ADMINISTRATOR"))
        //{
        //    this.btnEdit.Visible = false;
        //}
        //else
        //{
        //    this.btnEdit.Visible = true;
        //}
    }
    #endregion

    private void ValidateFields()
    {
        EPolicy.Login.Login cp = HttpContext.Current.User as EPolicy.Login.Login;
        int userID = 0;
        userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

        ArrayList errorMessages = new ArrayList();

        EPolicy.TaskControl.Application taskControl = (EPolicy.TaskControl.Application)Session["TaskControl"];

        try
        {
            if (errorMessages.Count > 0)
            {
                string popUpString = "";

                foreach (string message in errorMessages)
                {
                    popUpString += message + " ";
                }

                throw new Exception(popUpString);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }



    protected void rdoMcaMedSocieties_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnNextTop_Click(object sender, EventArgs e)
    {
        Save();
    }
    protected void btnNextBottom_Click(object sender, EventArgs e)
    {
        Save();
    }
    protected void btnPrevBottom_Click(object sender, EventArgs e)
    {
        Response.Redirect("Application5.aspx");
    }
    protected void btnPrevTop_Click(object sender, EventArgs e)
    {
        Response.Redirect("Application5.aspx");
    }
}
