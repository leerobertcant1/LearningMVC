using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningMVC.Controllers
{
    public class FoodsController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }
    }
}
