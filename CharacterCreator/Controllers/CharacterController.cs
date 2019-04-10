using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CharCreator.Data;
using CharCreator.Models;
using CharCreator.Services;
using Microsoft.AspNet.Identity;

namespace CharacterCreator.Controllers
{
    public class CharacterController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Character
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharService(userId);
            var model = service.GetCharacters();
            return View(model);
        }

        // GET: Character/Details/5
        public ActionResult Details(int? id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharService(userId);
            var model = service.GetCharacterById(id);

            var charRaceService = new CharRaceServices();
            var raceList = charRaceService.GetRaces();

            ViewBag.CharRaceID = new SelectList(raceList, "ID", "RaceName");

            var charClassService = new CharClassServices();
            var classList = charClassService.GetClasses();

            ViewBag.CharClassID = new SelectList(classList, "ID", "ClassName");

            return View(model);
        }

        // GET: Character/Create
        public ActionResult Create()
        {
            var charRaceService = new CharRaceServices();
            var raceList = charRaceService.GetRaces();

            ViewBag.CharRaceID = new SelectList(raceList, "ID", "RaceName");

            var charClassService = new CharClassServices();
            var classList = charClassService.GetClasses();

            ViewBag.CharClassID = new SelectList(classList, "ID", "ClassName");

            return View();
        }



        // POST: Character/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharService(userId);
            if (service.Create(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Character could not be added");
            return View(model);
        }

        // GET: Character/Edit/5
        public ActionResult Edit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharService(userId);

            var charClassService = new CharClassServices();
            var classList = charClassService.GetClasses();

            ViewBag.CharClassID = new SelectList(classList, "ID", "ClassName");

            var detail = service.GetCharacterById(id);
            var model = new CharDetail
            {
                CharName = detail.CharName,
                CharClassID = detail.CharClassID,
                Alignment = detail.Alignment,
                CharHistory = detail.CharHistory,
                ExperiencePoints = detail.ExperiencePoints,
                Traits = detail.Traits,
                Level = detail.Level,
            };

            return View(model);
        }

        // POST: Character/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(CharEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharService(userId);

            if (service.UpdateCharacter(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Character could not be edited.");
            return View(model);
        }

        // GET: Character/Delete/5
        public ActionResult Delete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharService(userId);

            var model = service.GetCharacterById(id);

            return View(model);
        }

        // POST: Character/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCharacter(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharService(userId);

            if (service.DeleteCharacter(id))
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
