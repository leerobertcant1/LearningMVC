using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LearningMVC.Models;
using Moq;

namespace LearningMVC.Controllers
{
    public class EFDataController : Controller
    {
        private LearningDB _db = new LearningDB();

        // GET: EFData
        public async Task<ActionResult> Index()
        {
            return View(await _db.People.ToListAsync());
        }

        // GET: EFData/Details/5
        public  async Task<ActionResult> Information([Bind(Prefix="id")] Guid personId)
        {
            Person model =  await _db.People.FindAsync(personId);
            if (model == null) return HttpNotFound();

            IList<Person> people = new List<Person>
            {
                new Person{FirstName = model.FirstName, LastName = model.LastName, Id = model.Id, MiddleName = model.MiddleName, Age = model.Age}
            };

            return View(people.AsEnumerable());         
        }

        // GET: EFData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EFData/Create
        //Responds to the form.
        //Bind checks for overposting; include whitelist or exclude blacklist.
        //Can also user a viewmodel instead of a binder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,MiddleName")] Person person)
        {
            //Handles model binding
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid();
                _db.People.Add(person);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //Return error to allow the user to handle.
            return View(person);
        }

        // GET: EFData/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Person person = await _db.People.FindAsync(id);
            if (person == null) return HttpNotFound();
            
            return View(person);
        }

        // POST: EFData/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,MiddleName")] Person person)
        {
            if (ModelState.IsValid)
            {
                //Track the person, not a new person, just track them.
                _db.Entry(person).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: EFData/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Person person = await _db.People.FindAsync(id);
            if (person == null) return HttpNotFound();
            
            return View(person);
        }

        // POST: EFData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Person person = await _db.People.FindAsync(id);
            _db.People.Remove(person);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _db.Dispose();
            
            base.Dispose(disposing);
        }
    }
}
