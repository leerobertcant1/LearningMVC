using LearningMVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningMVC.Controllers
{
    [Log]
    public class TestController : Controller
    {
        //This checks the url for this - also checks the query string.
        [HttpGet]
        public ActionResult Encode(int number)
        {
            //Prevents XSS attacks, this is what Razor does.
            var message = Server.HtmlEncode(number.ToString());

            return Content(ReturnEmptyString() + " " + number);
        }

        //Redirect to an action.
        [HttpGet]
        public ActionResult Redirect(int number = 0)
        {
            //if i want to pass in the number - 2nd param comes from route.config

            //return RedirectToAction("Lee", "Test", new { number = number });
            return RedirectToRoute("Test", new { number = number});
        }

        [Authorize(Roles ="Admin")]
        public ActionResult Authorise()
        {
            return Content("You are authorised");
        }

        [HttpGet]
        public ActionResult CSS()
        {
            return Content("You need to post!");
        }

        [HttpPost]
        public ActionResult CSS(bool posted)
        {
            return File(Server.MapPath("~/Content/Site.css"), "text/css");
        }

        [HttpGet]
        public ActionResult JSON(string json = "json string")
        {
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public virtual string ReturnEmptyString(string emptyString = "")
        {
            return "returns an empty string to browser";
        }
    }
}