using System;
using System.Web;
using System.Collections.Generic; // adicionado using

namespace Mod03_WebApplications.ThumbsAndWatermarking.WebApp.Exercicios
{
    public class RequestTimeModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            //context.LogRequest += new EventHandler(OnLogRequest);
            context.BeginRequest += new EventHandler(context_BeginRequest); // adicionada linha , a anterior nao sera necessaria
            context.PostRequestHandlerExecute += new EventHandler(context_PostRequestHandlerExecute); // adicionada linha
        }

        void context_BeginRequest(object sender, EventArgs e) // adicionado metodo
        {
            //throw new NotImplementedException();
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            SessionExtension.SetTimeNow();
        }

        void context_PostRequestHandlerExecute(object sender, EventArgs e) // adicionado metodo
        {
            //throw new NotImplementedException();
            SessionExtension.CalculateTimeSpan();
        }

        #endregion

        //public void OnLogRequest(Object source, EventArgs e)
        //{
        //    //custom logging logic can go here
        //}
    }
}
