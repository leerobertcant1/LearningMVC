using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningMVC.Controllers
{
    public class ES6Controller : Controller
    {
        // GET: ES6
        public ActionResult Index()
        {
            return View();
        }

        // GET: ES6/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ES6/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ES6/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ES6/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ES6/Edit/5
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

        // GET: ES6/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ES6/Delete/5
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
