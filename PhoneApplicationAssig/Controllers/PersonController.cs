using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhoneApplicationAssig.DAL;
using PhoneApplicationAssig.Models;

namespace PhoneApplicationAssig.Controllers
{
    public class PersonController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Person
        public ActionResult Index(String searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var people = db.Persons.Where(p => (p.FirstName.Contains(searchString) ||
                                                   p.LastName.Contains(searchString) ||

                                                   p.PhoneNumber.Contains(searchString))
                                                    );
                return View(people.ToList());
            }
            var peoples = db.Persons.Include(p => p.City).Include(p => p.Country).Include(p => p.State);
            peoples = peoples.Where(p => p.IsActive.Equals(true));
            return View(peoples.ToList());
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
            ViewBag.CountryId = new SelectList(db.Countries, "ContryId", "CountryName");
            ViewBag.StateId = new SelectList(db.States, "SateId", "StateName");
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,EmailId,PhoneNumber,AddressOne,AddressTwo,PinCode,CountryId,StateId,CityId,IsActive")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", person.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "ContryId", "CountryName", person.CountryId);
            ViewBag.StateId = new SelectList(db.States, "SateId", "StateName", person.StateId);
            return View(person);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", person.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "ContryId", "CountryName", person.CountryId);
            ViewBag.StateId = new SelectList(db.States, "SateId", "StateName", person.StateId);
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,EmailId,PhoneNumber,AddressOne,AddressTwo,PinCode,CountryId,StateId,CityId,IsActive")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", person.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "ContryId", "CountryName", person.CountryId);
            ViewBag.StateId = new SelectList(db.States, "SateId", "StateName", person.StateId);
            return View(person);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
