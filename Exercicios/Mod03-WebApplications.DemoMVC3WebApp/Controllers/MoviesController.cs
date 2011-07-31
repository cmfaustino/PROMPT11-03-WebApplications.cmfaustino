using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mod03_WebApplications.DemoMVC3WebApp.Controllers
{
    using Mod03_ChelasMovies.DomainModel;
    using Mod03_ChelasMovies.DomainModel.Services;

    public class MoviesController : Controller
    {
        IMoviesService repository;

        public MoviesController(IMoviesService repository)
        {
            this.repository = repository;
        }

        //
        // GET: /Movies/

        public ActionResult Index()
        {
            
            IEnumerable<Movie> movies = repository.GetAllMovies();
            return View(movies);
        }

        //
        // GET: /Movies/Details/5

        public ActionResult Details(int id)
        {
            Movie m = repository.Get(id);
            return View(m);
        }

        //
        // GET: /Movies/Create
        public ActionResult Create()
        {
            return View(new Movie());
        } 

        //
        // POST: /Movies/Create

        [HttpPost]
        public ActionResult Create(Movie m)
        {
            if (ModelState.IsValid)
            {
                repository.Add(m);
                return RedirectToAction("Index");
            }
            return View(m);
        }
        
        //
        // GET: /Movies/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Movies/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Movies/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Movies/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
