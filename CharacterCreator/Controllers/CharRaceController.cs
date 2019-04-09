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
using Microsoft.AspNet.Identity;

namespace CharacterCreator.Controllers
{
    public class CharRaceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CharRace
        public ActionResult Index()
        {
            var service = new CharRaceServices();
            var model = service.GetRaces();
            return View(model);
        }

        // GET: CharRace/Details/5
        public ActionResult Details(int id)
        {
            var service = new CharRaceServices();
            var model = service.GetRaceById(id);

            return View(model);
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
        public ActionResult Edit(int id)
        {
            var service = new CharRaceServices();

            var detail = service.GetRaceById(id);
            var model = new CharRaceEdit
            {
                RaceName = detail.RaceName,
                Size = detail.Size,
                Speed = detail.Speed,
                SpecialAttributes = detail.SpecialAttributes,
                Languages = detail.Languages,
            };

            return View(model);
        }

        // POST: CharRace/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CharRaceEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new CharRaceServices();

            if (service.UpdateRaces(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Race could not be edited.");
            return View(model);
        }

        // GET: CharRace/Delete/5
        public ActionResult Delete(int id)
        {
            var service = new CharRaceServices();

            var model = service.GetRaceById(id);

            return View(model);
        }

        // POST: CharRace/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var service = new CharRaceServices();

            if (service.DeleteRace(id))
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
