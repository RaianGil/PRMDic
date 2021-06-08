using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using EPolicy;
using EPolicy.TaskControl;

namespace EPolicy2.Reports.PRMdic
{
    /// <summary>
    /// Summary description for Solicitud9.
    /// </summary>
    public partial class Solicitud9 : DataDynamics.ActiveReports.ActiveReport3
    {
        private EPolicy.TaskControl.Application _taskcontrol;

        public Solicitud9(EPolicy.TaskControl.Application taskcontrol)
        {
            _taskcontrol = taskcontrol;
            InitializeComponent();
        }

        private void Solicitud9_ReportStart(object sender, EventArgs e)
        {
            if (_taskcontrol.McaAngio)
                this.CHKMcaAngio.Checked = true;

            if (_taskcontrol.McaAngioPTA)
                this.CHKMcaAngioPTA.Checked = true;

            if (_taskcontrol.McaAorto)
                this.CHKMcaAorto.Checked = true;

            if (_taskcontrol.McaBiopsy)
                this.CHKMcaBiopsy.Checked = true;

            if (_taskcontrol.McaBreast)
                this.chkMcaBreast.Checked = true;

            if (_taskcontrol.McaBreastImpl)
                this.chkMcaBreastImpl.Checked = true;

            if (_taskcontrol.McaCardiac)
                this.chkMcaCardiac.Checked = true;

            if (_taskcontrol.McaCoronary)
                this.chkMcaCoronary.Checked = true;

            if (_taskcontrol.McaCholangio)
                this.chkMcaCholangio.Checked = true;

            if (_taskcontrol.McaContrast)
                this.chkMcaContrast.Checked = true;

            if (_taskcontrol.McaEndo)
                this.chkMcaEndo.Checked = true;

            if (_taskcontrol.McaHexa)
                this.chkMcaHexa.Checked = true;

            if (_taskcontrol.McaIntraO)
                this.chkMcaIntraO.Checked = true;

            if (_taskcontrol.McaIntraG)
                this.chkMcaIntraG.Checked = true;

            if (_taskcontrol.McaIvp)
                this.chkMcaIvp.Checked = true;

            if (_taskcontrol.McaKidney)
                this.chkMcaKidney.Checked = true;

            if (_taskcontrol.McaLiver)
                this.chkMcaLiver.Checked = true;

            if (_taskcontrol.McaLipo)
                this.chkMcaLipo.Checked = true;

            if (_taskcontrol.McaLung)
                this.chkMcaLung.Checked = true;

            if (_taskcontrol.McaMyelo)
                this.chkMcaMyelo.Checked = true;

            if (_taskcontrol.McaPaceT)
                this.chkMcaPaceT.Checked = true;

            if (_taskcontrol.McaPaceP)
                this.chkMcaPaceP.Checked = true;

            if (_taskcontrol.McaPercuT)
                this.chkMcaPercuT.Checked = true;

            if (_taskcontrol.McaPercuG)
                this.chkMcaPercuG.Checked = true;

            if (_taskcontrol.McaPerio)
                this.chkMcaPerio.Checked = true;

            if (_taskcontrol.McaProstate)
                this.chkMcaProstate.Checked = true;

            if (_taskcontrol.McaRadio)
                this.chkMcaRadio.Checked = true;

            if (_taskcontrol.McaSilicone)
                this.chkMcaSilicone.Checked = true;

            if (_taskcontrol.McaSaline)
                this.chkMcaSaline.Checked = true;

            if (_taskcontrol.McaThera)
                this.chkMcaThera.Checked = true;

            if (_taskcontrol.McaUseL)
                this.chkMcaUseL.Checked = true;

            if (_taskcontrol.McaUseC)
                this.chkMcaUseC.Checked = true;

            if (_taskcontrol.McaAnes)
                this.chkMcaAnes.Checked = true;

            if (_taskcontrol.McaCardio)
                this.chkMcaCardio.Checked = true;

            if (_taskcontrol.McaChymo)
                this.chkMcaChymo.Checked = true;

            if (_taskcontrol.McaColon)
                this.chkMcaColon.Checked = true;

            if (_taskcontrol.McaGen)
                this.chkMcaGen.Checked = true;

            if (_taskcontrol.McaGyne)
                this.chkMcaGyne.Checked = true;

            if (_taskcontrol.McaHand)
                this.chkMcaHand.Checked = true;

            if (_taskcontrol.McaHead)
                this.chkMcaHead.Checked = true;

            if (_taskcontrol.McaLapa)
                this.chkMcaLapa.Checked = true;

            if (_taskcontrol.McaOther)
                this.chkMcaOther.Checked = true;

            if (_taskcontrol.App6mcaLipo)
                this.chkMcaLipo1.Checked = true;

            if (_taskcontrol.McaNeuro)
                this.chkMcaNeuro.Checked = true;

            if (_taskcontrol.McaObs)
                this.chkMcaObs.Checked = true;

            if (_taskcontrol.McaOph)
                this.chkMcaOph.Checked = true;

            if (_taskcontrol.McaOrth)
                this.chkMcaOrth.Checked = true;

            if (_taskcontrol.McaOrtho)
                this.chkMcaOrtho.Checked = true;

            if (_taskcontrol.McaPlaSurElective)
                this.chkMcaPlaSurElective.Checked = true;

            if (_taskcontrol.McaPlaSurOther)
                this.chkMcaPlaSurOther.Checked = true;

            if (_taskcontrol.McaRefra)
                this.chkMcaRefra.Checked = true;

            this.tstOrthYear.Text = _taskcontrol.OrthoYear;
            this.txtAnesPercent.Text = _taskcontrol.AnesPercent;
            this.txtAnesYear.Text = _taskcontrol.AnesYear;
            this.TXTAngioNumber.Text = _taskcontrol.AngioNumber;
            this.TXTAngioPTANumber.Text = _taskcontrol.AngioPTANumber;
            this.TXTAortoNumber.Text = _taskcontrol.AortoNumber;
            this.TXTBiopsyNumber.Text = _taskcontrol.BiopsyNumber;
            this.txtBreastImplNumber.Text = _taskcontrol.BreastImplNumber;
            this.txtBreastNumber.Text = _taskcontrol.BreastNumber;
            this.txtCardiacNumber.Text = _taskcontrol.CardiacNumber;
            this.txtCardioPercent.Text = _taskcontrol.CardioPercent;
            this.txtCardioYear.Text = _taskcontrol.CardioYear;
            this.txtCholangioNumber.Text = _taskcontrol.CholangioNumber;
            this.txtChymoPercent.Text = _taskcontrol.ChymoPercent;
            this.txtChymoYear.Text = _taskcontrol.ChymoYear;
            this.txtColonPercent.Text = _taskcontrol.ColonPercent;
            this.txtColonYear.Text = _taskcontrol.ColonYear;
            this.txtContrastNumber.Text = _taskcontrol.ContrastNumber;
            this.txtCoronaryNumber.Text = _taskcontrol.CoronaryNumber;
            this.txtEndoNumber.Text = _taskcontrol.EndoNumber;
            this.txtGenPercent.Text = _taskcontrol.GenPercent;
            this.txtGenYear.Text = _taskcontrol.GenYear;
            this.txtGynePercent.Text = _taskcontrol.GynePercent;
            this.txtGyneYear.Text = _taskcontrol.GyneYear;
            this.txtHandPercent.Text = _taskcontrol.HandPercent;
            this.txtHandYear.Text = _taskcontrol.HandYear;
            this.txtHeadPercent.Text = _taskcontrol.HandPercent;
            this.txtHeadYear.Text = _taskcontrol.HeadYear;
            this.txtHexaNumber.Text = _taskcontrol.HexaNumber;
            this.txtIntraGNumber.Text = _taskcontrol.IntraGNumber;
            this.txtIntraONumber.Text = _taskcontrol.IntraONumber;
            this.txtIvpNumber.Text = _taskcontrol.IvpNumber;
            this.txtKidneyNumber.Text = _taskcontrol.KidneyNumber;
            this.txtLapaPercent.Text = _taskcontrol.LapaPercent;
            this.txtLapaYear.Text = _taskcontrol.LapaYear;
            this.txtLipoNumber.Text = _taskcontrol.LipoNumber;
            this.txtLipoPercent.Text = _taskcontrol.LipoPercent;
            this.txtLipoYear.Text = _taskcontrol.LipoYear;
            this.txtLiverNumber.Text = _taskcontrol.LiverNumber;
            this.txtLungNumber.Text = _taskcontrol.LungNumber;
            this.txtMyeloNumber.Text = _taskcontrol.MyeloNumber;
            this.txtObsPercent.Text = _taskcontrol.ObsPercent;
            this.txtObsYear.Text = _taskcontrol.ObsYear;
            this.txtOphPercent.Text = _taskcontrol.OphPercent;
            this.txtOphYear.Text = _taskcontrol.OphYear;
            this.txtOrthoReplacePercent.Text = _taskcontrol.OrthoReplacePercent;
            this.txtOrthoReplaceYear.Text = _taskcontrol.OrthoReplaceYear;
            this.txtOrthPercent.Text = _taskcontrol.OrthPercent;
            this.txtOtherPercent.Text = _taskcontrol.OtherPercent;
            this.txtOtherYear.Text = _taskcontrol.OtherYear;
            this.txtPaceNumberP.Text = _taskcontrol.PaceNumberP;
            this.txtPaceNumberT.Text = _taskcontrol.PaceNumberT;
            this.txtPercuNumberG.Text = _taskcontrol.PercuNumberG;
            this.txtPercuNumberT.Text = _taskcontrol.PercuNumberT;
            this.txtPerioNumber.Text = _taskcontrol.PerioNumber;
            this.txtPlaSurElectivePercent.Text = _taskcontrol.PlaSurElectivePercent;
            this.txtPlaSurElectiveYear.Text = _taskcontrol.PlaSurElectiveYear;
            this.txtPlaSurOtherPercent.Text = _taskcontrol.PlaSurOtherPercent;
            this.txtPlaSurOtherYear.Text = _taskcontrol.PlaSurOtherYear;
            this.txtProstateNumber.Text = _taskcontrol.ProstateNumber;
            this.txtRadioNumber.Text = _taskcontrol.RadioNumber;
            this.txtRefraPercent.Text = _taskcontrol.RefraPercent;
            this.txtRefraYear.Text = _taskcontrol.RefraYear;
            this.txtSalineNumber.Text = _taskcontrol.SalineNumber;
            this.txtSiliconeNumber.Text = _taskcontrol.SiliconeNumber;
            this.txtTheraNumber.Text = _taskcontrol.TheraNumber;
            this.txtUseNumberC.Text = _taskcontrol.UseNumberC;
            this.txtUseNumberL.Text = _taskcontrol.UseNumberL;    
        }
    }
}
