namespace Mod03_ChelasMovies.Tests.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Mod03_ChelasMovies.Tests.Utils;
    using Mod03_ChelasMovies.WebApp;

    using NUnit.Framework;

    [TestFixture]
    public class UrlTests
    {
        [Test]
        public void ForwardSlashGoesToHomeIndex()
        {
            // Arrange (obtain routing config + set up test context)
            RouteCollection routeCollection = new RouteCollection();
            MvcApplication.RegisterRoutes(routeCollection);
            HttpContextBase testContext = new TestHttpContext("~/");
            // Act (run the routing engine against this HttpContextBase)
            RouteData routeData = routeCollection.GetRouteData(testContext);
            // Assert
            Assert.IsNotNull(routeData, "NULL RouteData was returned");
            Assert.IsNotNull(routeData.Route, "No route was matched");
            Assert.AreEqual("Home", routeData.Values["controller"], "Wrong controller");
            Assert.AreEqual("Index", routeData.Values["action"], "Wrong action");

        }

        [Test]
        public void SlashMoviesGoesToMoviesIndex()
        {
            // Arrange (obtain routing config + set up test context)
            RouteCollection routeCollection = new RouteCollection();
            MvcApplication.RegisterRoutes(routeCollection);
            HttpContextBase testContext = new TestHttpContext("~/Movies");
            // Act (run the routing engine against this HttpContextBase)
            RouteData routeData = routeCollection.GetRouteData(testContext);
            // Assert
            Assert.IsNotNull(routeData, "NULL RouteData was returned");
            Assert.IsNotNull(routeData.Route, "No route was matched");
            Assert.AreEqual("Movies", routeData.Values["controller"], "Wrong controller");
            Assert.AreEqual("Index", routeData.Values["action"], "Wrong action");

        }


        [Test]
        public void SlashMoviesDetailsWithNumericIdMatchesMoviesRoute()
        {
            // Arrange (obtain routing config + set up test context)
            RouteCollection routeCollection = new RouteCollection();
            MvcApplication.RegisterRoutes(routeCollection);
            HttpContextBase testContext = new TestHttpContext("~/Movies/Details/1");
            // Act (run the routing engine against this HttpContextBase)
            RouteData routeData = routeCollection.GetRouteData(testContext);
            // Assert
            Assert.IsNotNull(routeData, "NULL RouteData was returned");
            Assert.IsNotNull(routeData.Route, "No route was matched");
            Assert.AreSame(routeCollection["Movies"], routeData.Route, "Wrong route");
            Assert.AreEqual("Movies", routeData.Values["controller"], "Wrong controller");
            Assert.AreEqual("Details", routeData.Values["action"], "Wrong action");
            Assert.AreEqual("1", routeData.Values["id"], "Wrong action");

        }


        #region Outbound Url generation with Routing

        [Test]
        public void ShoudGEnerateSlashRouteToHomeIndex()
        {
            // Arrange
            RouteCollection routeCollection = new RouteCollection();
            MvcApplication.RegisterRoutes(routeCollection);
            //UrlHelper helper = new UrlHelper(null, routeCollection);

            // Act

            string url = UrlHelper.GenerateUrl(null, null, null, new RouteValueDictionary(new { controller = "Home", action = "Index" }), routeCollection, null, true);


            // Assert
            Assert.AreEqual("/", url);

        }



        #endregion Outbound Url generation with Routing


    }
}
