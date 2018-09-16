using LearningMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace LearningMVC.Controllers
{
    public class InfrastructureController : Controller
    {
        LearningDB _db = new LearningDB();

        [ChildActionOnly]
        [OutputCache(Duration = 60)]
        public ActionResult ChildAction()
        {
            return Content("Child cache");
        }

        //Caches data in seconds amd caches on server and caches the page views
        [OutputCache(Duration = 3600, VaryByHeader = "X-Requested-With", Location = OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            var model = _db.People
                .OrderByDescending(p => p.LastName)
                .Take(5);

            return View(model);
        }

        //Set in web config
        [OutputCache(CacheProfile ="Short", VaryByHeader = "X-Requested-With", Location = OutputCacheLocation.Server)]
        public ActionResult CacheProfile()
        {
            var model = _db.People
               .OrderByDescending(p => p.LastName)
               .Take(5); 

            return View(model);
        }
    }
}