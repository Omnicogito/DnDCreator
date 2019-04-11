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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoryCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new StoryService();
            if (service.Create(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Class could not be added");
            return View(model); ;
        }
    }
}