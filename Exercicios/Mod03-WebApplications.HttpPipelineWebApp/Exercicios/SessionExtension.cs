using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Mod03_WebApplications.ThumbsAndWatermarking.WebApp.Exercicios
{
    public static class SessionExtension
    {
        public static void CreateTimeSpans() // this System.Web.SessionState.HttpSessionState ses)
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["ServiceTimes"] = new Dictionary<Uri, List<Tuple<DateTime, DateTime, long>>>(); // long // TimeSpan
                //ses["ServiceTimes"] = new Dictionary<string, List<TimeSpan>>();
            }
        }

        public static void SetTimeNow() // this System.Web.SessionState.HttpSessionState ses
        {
            HttpContext.Current.Items["InitialTime"] = (DateTime) DateTime.Now;
        }

        public static void CalculateTimeSpan() // this System.Web.SessionState.HttpSessionState ses
        {
            if (HttpContext.Current.Session != null)
            {
                var times = (Dictionary<Uri, List<Tuple<DateTime, DateTime, long>>>)HttpContext.Current.Session["ServiceTimes"]; // long // TimeSpan
                var initialTime = (DateTime)HttpContext.Current.Items["InitialTime"];
                var finalTime = DateTime.Now;
                var interval = (finalTime - initialTime).Ticks;
                if (!times.ContainsKey(HttpContext.Current.Request.Url))
                {
                    times.Add(HttpContext.Current.Request.Url, new List<Tuple<DateTime, DateTime, long>>());
                }
                times[HttpContext.Current.Request.Url].Add(new Tuple<DateTime, DateTime, long>(initialTime, finalTime,
                                                                                               interval));
            }
        }

        public static string ViewTimeSpans()
        {
            StringBuilder sb = new StringBuilder();
            if (HttpContext.Current.Session != null)
            {
                var times = (Dictionary<Uri, List<Tuple<DateTime, DateTime, long>>>)HttpContext.Current.Session["ServiceTimes"]; // long // TimeSpan
                foreach (var time in times)
                {
                    sb.Append("<table><tr><td colspan=3><b>");
                    sb.Append(time.Key);
                    sb.Append("</b></td></tr>");
                    foreach (var timevalue in time.Value)
                    {
                        sb.Append("<tr><td>" + timevalue.Item1 + "</td><td>" + timevalue.Item2 + "</td><td>" + timevalue.Item3 + "</td></tr>");
                    }
                    sb.Append("</table>");
                }
                if (!times.ContainsKey(HttpContext.Current.Request.Url))
                {
                    sb.Append("<p>Não há tempos para este URL !</p>");
                }
                else
                {
                    sb.Append("<table><tr><td colspan=3><b>");
                    sb.Append(HttpContext.Current.Request.Url);
                    sb.Append("</b></td></tr>");
                    foreach (var time in times[HttpContext.Current.Request.Url])
                    {
                        sb.Append("<tr><td>" + time.Item1 + "</td><td>" + time.Item2 + "</td><td>" + time.Item3 + "</td></tr>");
                    }
                    sb.Append("</table>");
                }
            }
            return sb.ToString();
        }
    }
}