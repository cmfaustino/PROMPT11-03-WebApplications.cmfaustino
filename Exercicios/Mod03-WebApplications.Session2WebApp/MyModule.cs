namespace Mod03_WebApplications.Session2WebApp
{
    using System;
    using System.Web;

    public class MyModule: IHttpModule
    {
        #region Implementation of IHttpModule

        public void Init(HttpApplication app)
        {
            app.BeginRequest += new EventHandler(app_BeginRequest);
            app.PreRequestHandlerExecute += new EventHandler(app_PreRequestHandlerExecute);
        }

        void app_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            
        }

        void app_BeginRequest(object sender, EventArgs e)
        {
            
        }

        public void Dispose()
        {
            
        }

        #endregion
    }
}