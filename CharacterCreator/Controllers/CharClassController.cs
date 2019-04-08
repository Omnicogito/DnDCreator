using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CharCreator.Data;

namespace CharacterCreator.Controllers
{
    public class CharClassController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CharClass
        public ActionResult Index()
        {
            var charClasses = db.CharClasses.Include(c => c.Character);
            return View(charClasses.ToList());
        }

        // GET: CharClass/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharClass charClass = db.CharClasses.Find(id);
            if (charClass == null)
            {
                return HttpNotFound();
            }
            return View(charClass);
        }

        // GET: CharClass/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Characters, "ID", "CharName");
            return View();
        }

        // POST: CharClass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ClassName,SpellCaster,HitPointsFirstLevel,Proficiencies")] CharClass charClass)
        {
            if (ModelState.IsValid)
            {
                db.CharClasses.Add(charClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Characters, "ID", "CharName", charClass.ID);
            return View(charClass);
        }

        // GET: CharClass/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharClass charClass = db.CharClasses.Find(id);
            if (charClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Characters, "ID", "CharName", charClass.ID);
            return View(charClass);
        }

        // POST: CharClass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ClassName,SpellCaster,HitPointsFirstLevel,Proficiencies")] CharClass charClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(charClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Characters, "ID", "CharName", charClass.ID);
            return View(charClass);
        }

        // GET: CharClass/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharClass charClass = db.CharClasses.Find(id);
            if (charClass == null)
            {
                return HttpNotFound();
            }
            return View(charClass);
        }

        // POST: CharClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CharClass charClass = db.CharClasses.Find(id);
            db.CharClasses.Remove(charClass);
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
