namespace Mod03_ChelasMovies.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Mod03_ChelasMovies.DomainModel;
    using Mod03_ChelasMovies.DomainModel.Services;
    using Mod03_ChelasMovies.DomainModel.ServicesImpl;
    using Mod03_ChelasMovies.WebApp.Controllers;

    using Moq;

    using NUnit.Framework;

    // when the movie controller index action executes
    //   it should render the default view
    //   it should pass a list of movies to the view


    [TestFixture]
    public class MoviesControllerTests
    {
        private IMoviesService _inMemoryMoviesService;
        MoviesController _controller;

        [SetUp]
        public void SetUp()
        {
            _inMemoryMoviesService = new InMemoryMoviesService();
            _controller = new MoviesController(this._inMemoryMoviesService);
        }

        #region Tests when Index action executes
        // Test if the view returned is the Index View

        [Test]
        public void ShouldRenderTheDefaultView1()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(String.Empty,  result.ViewName);
        }

        [Test]
        public void ShouldPassAnIEnumerableOfMoviesAsModel1()
        {
            // Arrange
            
            

            // Act
            ViewResult result = _controller.Index() as ViewResult;


            // Assert
            IEnumerable<Movie> model = result.Model as IEnumerable<Movie>;
            Assert.IsNotNull(model);
            Assert.AreSame(this._inMemoryMoviesService.GetAllMovies(), model);

        }

        [Test]
        public void ShouldRenderTheDefaultView()
        {
            var serviceMock = new Mock<IMoviesService>();
            var controller = new MoviesController(serviceMock.Object);

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("", result.ViewName);
        }

        [Test]
        public void ShouldPassAnIEnumerableOfMoviesAsModel()
        {
            var movies = new List<Movie>
            {
                new Movie { Title="foo" },
                new Movie { Title="bar" }
            };

            var service = new Mock<IMoviesService>();
            var controller = new MoviesController(service.Object);
            service.Setup(r => r.GetAllMovies())
                      .Returns(movies);

            ViewResult result = controller.Index() as ViewResult;
            IEnumerable<Movie> model = result.ViewData.Model as IEnumerable<Movie>;

            Assert.IsTrue(movies.SequenceEqual(model));
        }

        #endregion Tests when Index action executes

        #region Tests when Create action executes

        // Create shouls fail and return the default view when the movie is invalid

        [Test]
        public void ShouldReturnTheDefaultViewOnCreatePostWhenMovieIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("xpto", "xpto");
            
            // Act 
            ViewResult result = _controller.Create(new Movie()) as ViewResult;

            // Assert
            Assert.AreEqual(String.Empty, result.ViewName); 

        }

        [Test]
        public void ShouldReturnARedirectResultToDetailsViewOnCreatePostWhenMovieValid()
        {
            // Arrange
            Movie m = new Movie { ID = 1, Title = "SomeTitle" };
            // Act 
            var result = _controller.Create(m) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual(String.Empty, result.RouteName);
            Assert.AreEqual("Details", result.RouteValues["action"]);
            Assert.AreEqual(null, result.RouteValues["controller"]);
            Assert.AreEqual(m.ID, result.RouteValues["id"]);

        }

        #endregion Tests when Create action executes
    }
}
