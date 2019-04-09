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
    public class CharClassController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CharClass
        public ActionResult Index()
        {
            var service = new CharClassServices();
            var model = service.GetClasses();
            return View(model);
        }

        // GET: CharClass/Details/5
        public ActionResult Details(int id)
        {
            var service = new CharClassServices();
            var model = service.GetClassById(id);
            return View(model);
        }

        // GET: CharClass/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CharClass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharClassCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new CharClassServices();
            if (service.Create(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Class could not be added");
            return View(model); ;
        }

        // GET: CharClass/Edit/5
        public ActionResult Edit(int id)
        {
            var service = new CharClassServices();

            var detail = service.GetClassById(id);
            var model = new CharClassEdit
            {
                ID = detail.ID,
                ClassName = detail.ClassName,
                SpellCaster = detail.SpellCaster,
                HitPointsFirstLevel = detail.HitPointsFirstLevel,
                Proficiencies = detail.Proficiencies
            };

            return View(model);
        }

        // POST: CharClass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CharClassEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new CharClassServices();

            if (service.UpdateClass(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Class could not be edited.");
            return View(model);
        }

        // GET: CharClass/Delete/5
        public ActionResult Delete(int id)
        {
            var service = new CharClassServices();

            var model = service.DeleteClass(id);

            return View(model);
        }

        // POST: CharClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var service = new CharClassServices();

            if (service.DeleteClass(id))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Delete", new { id });
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
