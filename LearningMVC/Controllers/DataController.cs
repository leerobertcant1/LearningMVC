using LearningMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningMVC.Controllers
{
    //Account handles this can use a custom attribute
    [Authorize(Users="Lee", Roles ="Admin")]
    public class DataController : Controller
    {
        LearningDB _db = new LearningDB();

        // GET: Data
        [AllowAnonymous]
        public ActionResult Index(string searchName = null)
        {
            //var model = from p in _db.People
            //            orderby p.FirstName descending
            //            select p;

            var model = _db.People.OrderBy(p => p.Id);

            return View(model);
        }

        public ActionResult FirstPerson()
        {

            return PartialView("_Person");
        }
        //Razor autohandles this, unless you use html.Raw()
        public ActionResult XSSTest()
        {
            string XSS = "<script> alert('xss');</script>";
            ViewBag.XSS = XSS;
            return View();
        }

        public ActionResult Edit(Guid id)
        {

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if(_db != null)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}