using LearningMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SetUrlData();

            return View();
        }
    
        public ActionResult About()
        {
            About model = new About();
            model.Name = "Lee Cant";
            model.Location = "Lincoln, UK";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private void SetUrlData()
        {
            //Getting url information
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];

            string url = $"The controller is {controller}; the action is {action}; the id is: {id}";

            ViewBag.UrlData = url;
        }
    }
}