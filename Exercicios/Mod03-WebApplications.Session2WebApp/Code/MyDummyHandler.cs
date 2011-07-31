namespace Mod03_WebApplications.Session2WebApp.Code
{
    using System;
    using System.Web;
    using System.Web.SessionState;

    public class MyDummyHandler : IHttpHandler, IRequiresSessionState
    {
        #region Implementation of IHttpHandler

        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests. </param>
        public void ProcessRequest(HttpContext context)
        {
            string format = null;
            //if (context.Request.RequestType == "GET")
            //{
            //    format = context.Request.QueryString["format"];
            //} else {
            //    format = context.Request.Form["format"];
            //}


            format = context.Request["format"];
            int cnt = (int)context.Session["count"];
            context.Session["count"] = ++cnt;


            string outStr = String.Format("Hello World - {0} - cnt = {1}", this.GetHashCode(), cnt); ;

            if (String.IsNullOrEmpty(format) || format == "plain")
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write(outStr);
                return;
            } 

            if(format == "html") {
                context.Response.ContentType = "text/html";
                context.Response.Write(String.Format("<html><body>{0}</body></html>", outStr));
                return;
            }

            // Return an error
            context.Response.StatusCode = 415;
            context.Response.Write("Erro");
        }

        /// <summary>
        /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler"/> instance.
        /// </summary>
        /// <returns>
        /// true if the <see cref="T:System.Web.IHttpHandler"/> instance is reusable; otherwise, false.
        /// </returns>
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        #endregion
    }
}