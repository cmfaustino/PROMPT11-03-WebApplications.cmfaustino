using System;
using System.Web.Mvc;
using Mod03_ChelasMovies.DomainModel;
using Mod03_ChelasMovies.DomainModel.Services;

namespace Mod03_ChelasMovies.WebApp.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        //
        // GET: /Movies/
        public ActionResult Index()
        {
            //Predicate<Movie> pred = null;
            //if(title != null)
            //{
            //    pred = m => m.Title.Contains(title);
            //}

            //if (year != null)
            //{
            //    pred = pred.And(m => m.Year == year);
            //}

            //object query = new { Title = title, Year = year };


            ICollection<Movie> movies = _moviesService.GetAllMovies();
            return View(movies);
        }


        public ActionResult Details(int id)
        {

            Movie movie = _moviesService.Get(id);
            if(movie == null)
            {
                return View("NotFound", id);
            }
            return View(movie);
        }

        public ActionResult Create()
        {
            return View(new Movie());
        }

        [HttpPost]
        public ActionResult Create(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                _moviesService.Add(newMovie);
                return RedirectToAction("Details", new { id = newMovie.ID });
            }
            else
            {
                return View(newMovie);
            }
        }

        public ActionResult CreateComment(int movieId)
        {
            Comment c = new Comment {MovieID = movieId};
            return View(c);
        }

        [HttpPost]
        public ActionResult CreateComment(Comment c)
        {
            try
            {
                if (ModelState.IsValid) {
                    Movie movie = _moviesService.Get(c.MovieID);
                    movie.Comments.Add(c);
                    _moviesService.Update(movie);
                    return RedirectToRoute("Default", new { action = "Details", id = c.MovieID });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", String.Format("Edit Failure, inner exception: {0}", e));
            }

            return View(c);
        }
    }
}
