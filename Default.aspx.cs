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
using System.Net;
using System.Web.Security;
using System.IO;
using System.Text;
using EPolicy.Login;
using System.Threading;
using System.Timers;
using System.Configuration;
using SpeechLib;

namespace EPolicy
{
    /// <summary>
    /// Summary description for WebForm1.
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //BeginEventHandler bh = new BeginEventHandler(BeginMethod);
            //EndEventHandler eh = new EndEventHandler(EndMethod);
            //this.AddOnPreRenderCompleteAsync(bh, eh);

            //this.litPopUp.Visible = false;

            Login.Login cp = HttpContext.Current.User as Login.Login;

            if (cp != null)
            {
                int userID = 0;
                userID = int.Parse(cp.Identity.Name.Split("|".ToCharArray())[1]);

                TxtUserName.Enabled = false;
                TxtPassword.Enabled = false;
                this.BtnLogIn.Visible = false;
                this.BtnSalir.Visible = true;
            }
            else
            {
                TxtUserName.Enabled = true;
                TxtPassword.Enabled = true;
                this.BtnLogIn.Visible = true;
                this.BtnSalir.Visible = false;
            }

            if (!IsPostBack)
            {
                if (this.Request.QueryString.ToString().Trim() == "001")
                {
                    lblRecHeader.Text = "No tienes privilegios para entrar a esta página.";
                    mpeSeleccion.Show();
                    //this.litPopUp.Text = Utilities.MakeLiteralPopUpString("No tienes privilegios para entrar a esta página.");
                    //this.litPopUp.Visible = true;
                }
                if (this.Request.QueryString.ToString().Trim() == "002") //Error entrando el username o password.
                {
                    if (Session["WrongPass"] != null)
                    {
                        string message = (string)Session["WrongPass"];

                        lblRecHeader.Text = message;
                        mpeSeleccion.Show();
                        //this.litPopUp.Text = Utilities.MakeLiteralPopUpString(message);
                        //this.litPopUp.Visible = true;
                        Session.Remove("WrongPass");
                    }
                }
                if (this.Request.QueryString.ToString().Trim() == "003") //Under Construction.
                {
                    if (Session["WrongPass"] != null)
                    {
                        string message = (string)Session["WrongPass"];
                        lblRecHeader.Text = message;
                        mpeSeleccion.Show();
                        //this.litPopUp.Text = Utilities.MakeLiteralPopUpString(message);
                        //this.litPopUp.Visible = true;
                        Session.Remove("WrongPass");
                    }
                }

                if (this.Request.QueryString.ToString().Trim() == "004") //Logout Message.
                {
                    if (Session["WrongPass"] != null)
                    {
                        string message = (string)Session["WrongPass"];
                        lblRecHeader.Text = message;
                        mpeSeleccion.Show();
                        //this.litPopUp.Text = Utilities.MakeLiteralPopUpString(message);
                        //this.litPopUp.Visible = true;
                        Session.Remove("WrongPass");
                    }
                }

                if (this.Request.QueryString.ToString().Trim() == "006") //Go To Main Menu when Login.
                {
                    if (Session["Message"] != null)
                    {
                        Session.Remove("Message");
                        Response.Redirect("Main.aspx");
                    }
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

            //Setup top Banner
            //    Control Banner = new Control();
            //    Banner = LoadControl(@"TopBanner.ascx");
            //    this.phTopBanner.Controls.Add(Banner);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        //protected IAsyncResult BeginMethod(object src, EventArgs arg, AsyncCallback cb, Object state)
        //{
        //    invokeTest = new InvokeTest(doWork);
        //    //_wr = WebRequest.Create("http://localhost/PRMDic/default.aspx");
        //    //Thread.Sleep(300000);
        //    return invokeTest.BeginInvoke(cb, state);
        //    //return _wr.BeginGetResponse(cb, state);
        //}

        //protected void EndMethod(IAsyncResult ar)
        //{
        //    try
        //    {
        //        //WebResponse newWR = _wr.EndGetResponse(ar);
        //        //string siteText;

        //        //StreamReader sr = new StreamReader(newWR.GetResponseStream());
        //       // siteText = sr.ReadToEnd();
        //        //Response.Write(siteText);
        //    }
        //    catch (Exception exc)
        //    {

        //    }
        //}

        //void doWork()
        //{
        //    System.Threading.Thread.Sleep(3000);
        //}


        protected void BtnLogIn_Click(object sender, System.EventArgs e)
        {
            Login.Login login = new Login.Login();
            try
            {
                string encrypt = FormsAuthentication.HashPasswordForStoringInConfigFile(TxtPassword.Text.Trim(), "SHA1");
                TxtPassword.Text = "";

                if (login.GetAuthenticatedUser(TxtUserName.Text.Trim(), encrypt))
                {
                    if ((login.AllDay) ||
                        (DateTime.Parse(login.Time1) <= DateTime.Parse(DateTime.Now.ToShortTimeString()) &&
                        DateTime.Parse(login.Time2) >= DateTime.Parse(DateTime.Now.ToShortTimeString()) &&
                        TiempoLimitadoAcceso(login)))
                    {
                        if (!login.ChangePassword)
                        {
                            //La propeidad IsPersistent se cambio a true para que el cookies dure solo 10 horas. Asi el usuario debe de hacer login de nuevo.
                            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, login.UserName + "|" + login.UserID.ToString(), DateTime.Now, DateTime.Now.AddHours(10), false, ""); //login.GetRole());

                            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                            HttpCookie authCookies = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                            //authCookies.HttpOnly = true;

                            Response.Cookies.Add(authCookies);

                            TxtUserName.Text = "";
                            TxtPassword.Text = "";
                            TxtUserName.Enabled = false;
                            TxtPassword.Enabled = false;
                            BtnLogIn.Visible = false;

                            Session.Add("Message", "message");

                            ////Speech
                            //SpVoiceClass voice = new SpVoiceClass();
                            //SpObjectToken dp = new SpObjectToken();
                            //SpVoiceClass k = new SpVoiceClass();

                            //voice.Volume = ;
                            //SpeechLib.ISpeechObjectTokens token = voice.GetVoices ("", ""); 
                            //voice.SetVoice ((SpeechLib.ISpObjectToken) token.Item (0)); 
                            //voice.Speak("Good Morning, Victor!", SpeechVoiceSpeakFlags.SVSFlagsAsync);
                            //voice.WaitUntilDone(50000);


                            //SpeechSynthesizer ss = new SpeechSynthesizer();

                            ////ss.SpeakSsmlAsync("Buenas Tarde! Victor Lanza");
                            ////ss.SpeakAsync("Buenas Tarde! Victor Lanza");
                            //ss.SelectVoice("LH Michael");
                            ////ss.SelectVoice("LH Michelle");

                            //PromptBuilder prompt = new PromptBuilder();
                            //PromptStyle mainStyle = new PromptStyle();

                            //mainStyle.Rate = PromptRate.Medium;
                            //mainStyle.Volume = PromptVolume.Loud;
                            //prompt.StartStyle(mainStyle);

                            //prompt.AppendText("Norma, Welcome to Puerto Rico Medical Defense Insurance Company.");
                            //prompt.AppendBreak();
                            //prompt.EndStyle();

                            //ss.SetOutputToWaveFile(@"c:\soundfile.wav");
                            //Thread.Sleep(3000);
                            //ss.SpeakAsync(prompt);
                            //Thread.Sleep(30000);
                            ////ss.SpeakAsyncCancelAll();
                        }
                        else
                        {
                            //For user that have change password.
                            throw new Exception("Por favor debes de cambiar su contraseña.");
                        }
                    }
                    else
                    {
                        //Restriccion de horario.
                        throw new Exception("Usted esta restringido para entrar al sistema a esta hora.");
                    }
                }
            }
            catch (Exception exp)
            {
                HttpCookie authCookies = new HttpCookie(FormsAuthentication.FormsCookieName, null);
                Response.Cookies.Add(authCookies);

                Session.Add("WrongPass", exp.Message);
                Response.Redirect("Default.aspx?002");
            }

            Response.Redirect("Search.aspx");
        }

        private bool TiempoLimitadoAcceso(Login.Login login)
        {
            string dayofweek = Utilities.DayofWeek(DateTime.Now.DayOfWeek.ToString().Trim().ToUpper());

            bool accessDays = false;

            switch (dayofweek)
            {
                case "DOMINGO":
                    if (login.Domingo)
                        accessDays = true;
                    else
                        accessDays = false;
                    break;
                case "LUNES":
                    if (login.Lunes)
                        accessDays = true;
                    else
                        accessDays = false;
                    break;
                case "MARTES":
                    if (login.Martes)
                        accessDays = true;
                    else
                        accessDays = false;
                    break;
                case "MIERCOLES":
                    if (login.Miercoles)
                        accessDays = true;
                    else
                        accessDays = false;
                    break;
                case "JUEVES":
                    if (login.Jueves)
                        accessDays = true;
                    else
                        accessDays = false;
                    break;
                case "VIERNES":
                    if (login.Viernes)
                        accessDays = true;
                    else
                        accessDays = false;
                    break;
                case "SABADO":
                    if (login.Sabado)
                        accessDays = true;
                    else
                        accessDays = false;
                    break;
            }
            return accessDays;
        }

        protected void BtnSalir_Click(object sender, System.EventArgs e)
        {
            HttpCookie authCookies = new HttpCookie(FormsAuthentication.FormsCookieName, null);
            Response.Cookies.Add(authCookies);

            Session.Add("WrongPass", "Salida del Usuario Satisfactoria!");
            Response.Redirect("Default.aspx?004");
        }
    }
}
