using LearningMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace LearningMVC.Controllers
{
    public class LogonController : Controller
    {
        LearningDB _db = new LearningDB();

        //Adds crypographically significant value, placed inside cookie, stops replication the form without this.
        //One site cannot amend a cookie for another site//Adds crypographically significant value, placed inside cookie, 
        //stops replication the form without this.One site cannot amend a cookie for another site
        //[ValidateAntiForgeryToken]
        [HttpGet]
        public ActionResult Login(FormCollection formCollection)
        {
            ViewBag.LoggedIn = string.Empty;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Users userData)
        {

            //WebSecurity.Login(userData.Username, userData.Password); 
            bool loggedIn = _db.Users.Any(u => u.Password == userData.Password && u.Username == u.Username);

            if (loggedIn)
            {
                ViewBag.LoggedIn = "Logged in Successfully";
            }
            else
            {
                ViewBag.LoggedIn = "Incorrect password";
            }
         
            return View();
        }
    }
}