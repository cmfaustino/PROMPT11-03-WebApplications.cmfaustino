using System;
using System.Web;
using System.Web.SessionState; // adicionado using

namespace Mod03_WebApplications.ThumbsAndWatermarking.WebApp.Exercicios
{
    public class RequestTimesHandler : IHttpHandler, IRequiresSessionState // adicionado IRequiresSessionState para obrigar a existir Session
    {
        /// <summary>
        /// You will need to configure this handler in the web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //write your handler implementation here.
            context.Response.Buffer = false;
            //context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.StatusCode = 400;
            context.Response.ContentType = "text/html";
            context.Response.Write("<html><head><title>Request Times</title></head><body>");
            context.Response.Write(SessionExtension.ViewTimeSpans());
            context.Response.Write("<html>");
            context.Response.Write("</body></html>");
        }

        #endregion
    }
}
