using CharCreator.Models;
using CharCreator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharacterCreator.Controllers
{
    public class StoryController : Controller
    {
        // GET: Story
        public ActionResult Index()
        {
            var service = new StoryService();
            var model = service.GetStories();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = new StoryService();
            var model = service.GetStorybyID(id);
            return View(model);
        }


        public ActionResult Create()
        {
            var charServices = new CharService();
            var charList = charServices.GetCharactersCharacters();

            ViewBag.Characters = new SelectList(charList, "ID", "CharName");


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoryCreate model)
        {
            if (!ModelState.IsValid)
            {
                var charServices = new CharService();
                var charList = charServices.GetCharactersCharacters();

                ViewBag.Characters = new SelectList(charList, "ID", "CharName");
                return View(model);
            }

            var service = new StoryService();
            if (service.Create(model))
            {
                var charServices = new CharService();
                var charList = charServices.GetCharactersCharacters();

                ViewBag.Characters = new SelectList(charList, "ID", "CharName");
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Story could not be added");
            return View(model); ;
        }




    }
}