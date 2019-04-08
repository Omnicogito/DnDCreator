using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CharCreator.Data;
using CharCreator.Models;
using CharCreator.Services;

namespace CharacterCreator.Controllers
{
    public class CharRaceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CharRace
        public ActionResult Index()
        {
            var charRaces = db.CharRaces;
            return View(charRaces.ToList());
        }

        // GET: CharRace/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharRace charRace = db.CharRaces.Find(id);
            if (charRace == null)
            {
                return HttpNotFound();
            }
            return View(charRace);
        }

        // GET: CharRace/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CharRace/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharRaceCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new CharRaceServices();
            if (service.Create(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Race Could not be Added");
            return View(model);
        }

        // GET: CharRace/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharRace charRace = db.CharRaces.Find(id);
            if (charRace == null)
            {
                return HttpNotFound();
            }
            return View(charRace);
        }

        // POST: CharRace/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RaceName,Size,Speed,SpecialAttributes,Languages")] CharRace charRace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(charRace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(charRace);
        }

        // GET: CharRace/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharRace charRace = db.CharRaces.Find(id);
            if (charRace == null)
            {
                return HttpNotFound();
            }
            return View(charRace);
        }

        // POST: CharRace/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CharRace charRace = db.CharRaces.Find(id);
            db.CharRaces.Remove(charRace);
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
