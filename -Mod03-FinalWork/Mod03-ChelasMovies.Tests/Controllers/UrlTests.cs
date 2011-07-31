using System.Web.Mvc;

namespace Mod03_WebApplications.DemoMVC3WebApp.Tests.Controllers
{
    using System.Web;
    using System.Web.Routing;

    using Mod03_ChelasMovies.WebApp;
    using Mod03_ChelasMovies.WebApp.Controllers;

    using Mod03_WebApplications.DemoMVC3WebApp.Tests.Utils;

    using NUnit.Framework;


    [TestFixture]
    public class UrlTests
    {
        [Test]
        public void ForwardSlashGoesToHomeIndex()
        {
            // Arrange (obtain routing config + set up test context)
            RouteCollection routeConfig = new RouteCollection();
            MvcApplication.RegisterRoutes(routeConfig);
            HttpContextBase testContext = new TestHttpContext("~/");
            // Act (run the routing engine against this HttpContextBase)
            RouteData routeData = routeConfig.GetRouteData(testContext);
            // Assert
            Assert.IsNotNull(routeData, "NULL RouteData was returned");
            Assert.IsNotNull(routeData.Route, "No route was matched");
            Assert.AreEqual("Home", routeData.Values["controller"], "Wrong controller");
            Assert.AreEqual("Index", routeData.Values["action"], "Wrong action");

        }
    }
}
