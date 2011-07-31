namespace Mod03_WebApplications.ThumbsAndWatermarking.WebApp {
    using System;
    using Exercicios; // adicionado using

    public class Global : System.Web.HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            SessionExtension.CreateTimeSpans(); // adicionada instrucao
            //Session.CreateTimeSpans(); // adicionada instrucao
        }

        protected void Application_BeginRequest(object sender, EventArgs e) {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {

        }

        protected void Application_Error(object sender, EventArgs e) {

        }

        protected void Session_End(object sender, EventArgs e) {

        }

        protected void Application_End(object sender, EventArgs e) {

        }

    }
}