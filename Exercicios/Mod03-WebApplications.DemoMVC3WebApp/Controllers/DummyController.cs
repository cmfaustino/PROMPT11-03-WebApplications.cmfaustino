using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mod03_WebApplications.DemoMVC3WebApp.Controllers
{
    public class DummyController : Controller
    {
        //
        // GET: /Dummy/

        public ActionResult Index()
        {
            return View();
        }

    }
}
