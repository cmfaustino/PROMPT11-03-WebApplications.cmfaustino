using System;
using System.Web.Mvc;
using Mod03_ChelasMovies.DomainModel;
using Mod03_ChelasMovies.DomainModel.Services;

namespace Mod03_ChelasMovies.WebApp.Controllers
{
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
            return View(_moviesService.GetAllMovies());
        }


        public ActionResult Details(int id)
        {

            Movie movie = _moviesService.Get(id);
            if(movie == null)
            {
                //return RedirectToAction("Index");
                return View("NotFound", id);
            }
            return View(movie);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie newMovie, string fillButton) // acrescentou-se 2o parametro com nome igual ao name do novo form submit
        {
            if (fillButton != null) // acrescentou-se if
            {
                Movie movie = _moviesService.Search(newMovie.Title);
                ModelState.Clear(); // 
                return View(movie);
            }
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

        public ActionResult Edit(int id) // ? parametro tem de ter nome igual a Global.asax.cs - RegisterRoutes - routes.MapRoute
        {

            Movie movie = _moviesService.Get(id);
            if (movie == null)
            {
                //return RedirectToAction("Index");
                return View("NotFound", id);
            }
            return View(movie);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(int id) // parametro tem de ter nome igual a Global.asax.cs - RegisterRoutes - routes.MapRoute
        {

            //Movie movie = _moviesService.Get(id);
            try
            {
                if (ModelState.IsValid)
                {
                    Movie movie = _moviesService.Get(id);
                    if (movie == null)
                    {
                        //return RedirectToAction("Index");
                        return View("NotFound", id);
                    }
                    UpdateModel(movie);
                    _moviesService.Update(movie);
                    return RedirectToAction("Details", new { id = id });
                }
                //else
                //{
                //    return Edit(id); // View(movie); // estara bem ? sim...
                //}
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", String.Format("Edit Failure, inner exception: {0}", e));
            }

            return Edit(id); // View(movie); // estara bem ? sim...
        }

        public ActionResult Delete(int id) // ? parametro tem de ter nome igual a Global.asax.cs - RegisterRoutes - routes.MapRoute
        {

            Movie movie = _moviesService.Get(id);
            if (movie == null)
            {
                //return RedirectToAction("Index");
                return View("NotFound", id);
            }
            return View(movie);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id) // parametro tem de ter nome igual a Global.asax.cs - RegisterRoutes - routes.MapRoute
        {

            //Movie movie = _moviesService.Get(id);
            try
            {
                if (ModelState.IsValid)
                {
                    Movie movie = _moviesService.Get(id);
                    if (movie == null)
                    {
                        //return RedirectToAction("Index");
                        return View("NotFound", id);
                    }
                    _moviesService.Delete(id);
                    //UpdateModel(movie);
                    //_moviesService.Update(movie);
                    //return RedirectToAction("Details", new { id = id });
                    return RedirectToAction("Index");
                }
                //else
                //{
                //    return Edit(id); // View(movie); // estara bem ? sim...
                //}
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", String.Format("Delete Failure, inner exception: {0}", e));
            }

            //return Edit(id); // View(movie); // estara bem ? sim...
            return RedirectToAction("Details", new { id = id });
            //return View(movie); // estara bem ? sim...
        }
    }
}
