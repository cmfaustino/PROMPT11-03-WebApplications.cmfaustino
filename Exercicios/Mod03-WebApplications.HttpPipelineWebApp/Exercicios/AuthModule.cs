using System;
using System.Web;

namespace Mod03_WebApplications.ThumbsAndWatermarking.WebApp.Exercicios
{
    public class AuthModule : IHttpModule
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
            context.AuthenticateRequest += new EventHandler(context_AuthenticateRequest);
            context.AuthorizeRequest += new EventHandler(context_AuthorizeRequest);
        }

        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void context_AuthorizeRequest(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion

        //public void OnLogRequest(Object source, EventArgs e)
        //{
        //    //custom logging logic can go here
        //}
    }
}
