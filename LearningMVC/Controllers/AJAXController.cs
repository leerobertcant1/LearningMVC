using LearningMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace LearningMVC.Controllers
{
    public class AJAXController : Controller
    {
        LearningDB _db = new LearningDB();

        public ActionResult Index(int page = 1)
        {
            var model = _db.People
                .OrderByDescending(p => p.LastName);

            //Checks if ajax call which doesnt lose scroll position
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/Shared/_ajax.cshtml", model.ToPagedList(page, 10));
            }

            return View(model.ToPagedList(page, 10));
        }

        [HttpPost]
        public ActionResult Index(int page = 1, string term = "")
        {
            var model = _db.People
                .OrderByDescending(p => p.LastName.Contains(term));

            return View(model.ToPagedList(page, 10));
        }

        public ActionResult Jquery()
        {
            return View();
        }

        //term default done by jquery
        public ActionResult AutoComplete(string term)       
        {
            var model = _db.People
                .Where(p => p.LastName.StartsWith(term))
                .Take(10)
                .Select(p => new
                {
                    label = p.LastName
                });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AJAXBegin()
        {

            var model = _db.People.OrderByDescending(p => p.LastName);

            //Checks if ajax call which doesnt lose scroll position
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/Shared/_ajax.cshtml", model);
            }

            return View(model);
        }
    }
}