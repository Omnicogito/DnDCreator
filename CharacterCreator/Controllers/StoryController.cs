using CharCreator.Data;
using CharCreator.Models;
using CharCreator.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static CharCreator.Models.StoryCreate;

namespace CharacterCreator.Controllers
{
    public class StoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private Character character;

        // GET: Story
        public ActionResult Index()
        {
            //var service = new StoryService();
            //var model = service.GetStories();
            //return View(model);

            return View(db.Stories.ToList().OrderBy(i => i.StoryName));
        }

        public ActionResult Details(int id)
        {
            var service = new StoryService();
            var model = service.GetStorybyID(id);
            return View(model);
        }


        public ActionResult Create()
        {
            //var charServices = new CharService();
            //var charList = charServices.GetCharactersCharacters();
            //ViewBag.Characters = new SelectList(charList, "ID", "CharName");

            //var character = new CharListItem();
            //character.Characters = new List<CharListItem>();


            //return View(new StoryCreate());

            MultiSelectList charList = new MultiSelectList(db.Characters.ToList().OrderBy(p => p.CharName), "ID", "CharName");
            StoryCreate story = new StoryCreate { Characters = charList };
            return View(story);
        }

        //private void PopulateCharacterField()
        //{
        //    var characterService = new CharService();

        //    var characters = characterService.GetCharactersCharacters();

        //    var viewModel = new List<CharListItem>();

        //    foreach(var cha in characters)
        //    {
        //        viewModel.Add(new CharListItem
        //        {
        //            CharName = cha.CharName,
        //            ID = cha.ID,
        //            Assigned = cha.Assigned,
        //        });
        //    }

        //    ViewBag.AllCharacters = viewModel;
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoryName, Description, CharacterIds")]StoryCreate model)
        {
            if (ModelState.IsValid)
            {
                Story story = new Story
                {
                    StoryName = model.StoryName,
                    ID = model.ID,
                    Description = model.Description
                };

                if (model.CharacterIds != null)
                {
                    foreach (var id in model.CharacterIds)
                    {
                        var charId = int.Parse(id);
                        var character = db.Characters.Find(charId);
                        try
                        {
                            story.Characters.Add(character);
                        }
                        catch (Exception ex)
                        {
                            return View("Error", new HandleErrorInfo(ex, "Story", "Index"));
                        }
                    }
                }
                try
                {
                    db.Stories.Add(story);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "Story", "Index"));
                }

                return RedirectToAction("Details", new { id = story.ID });
            }
            else
            {
                ModelState.AddModelError("", "Something failed.");
                return View(model);
            }

            //    if (!ModelState.IsValid)
            //    {
            //        //var charServices = new CharService();
            //        //var charList = charServices.GetCharactersCharacters();

            //        //ViewBag.CharactersForStory = new SelectList(charList, "ID", "CharName");
            //        //return View(model);

            //        MultiSelectList charList = new MultiSelectList(db.Teams.ToList().OrderBy(i => i.Name), "TeamId", "Name");
            //    }

            //    var service = new StoryService();
            //    if (service.Create(model))
            //    {
            //        var charServices = new CharService();
            //        var charList = charServices.GetCharactersCharacters();

            //        ViewBag.CharactersForStory = new SelectList(charList, "ID", "CharName");
            //        return RedirectToAction("Index");
            //    }

            //    ModelState.AddModelError("", "Story could not be added");
            //    return View(model); ;
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Retrieve Story from db and perform null check
            Story story = db.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            // Instantiate new instance of EditStoryCreateModel
            EditStoryCreate model = new EditStoryCreate
            {
                // Can set the player name and Id filds of the ViewModel
                StoryId = story.ID.ToString(),
                StoryName = story.StoryName
            };

            // Retrieve list of story characters from db in order to find the characters that the story belongs to
            var storyCharacters = db.Characters.Where(i => i.Stories.Any(j => j.ID.Equals(story.ID))).ToList();
            //var playerTeams = db.Teams.Where(t => t.Players.Contains(new Player { PlayerId = player.PlayerId })).ToList();

            // Check that playerTeams is not empty
            if (storyCharacters != null)
            {
                // Initialize the array to number of characters in storyCharacters
                string[] storyCharactersIds = new string[storyCharacters.Count];

                // Then, set the value of platerTeams.Count so the for loop doesn't need to work it out every iteration
                int length = storyCharacters.Count;

                // Now loop over each of the playerTeams and store the Id in the playerTeamsId array
                for (int i = 0; i < length; i++)
                {
                    // Note that we employ the ToString() method to convert the Guid to the string
                    storyCharactersIds[i] = storyCharacters[i].ID.ToString();
                }

                // Instantiate the MultiSelectList, plugging in our playerTeamIds array
                MultiSelectList characterList = new MultiSelectList(db.Characters.ToList().OrderBy(i => i.CharName), "ID", "CharName", storyCharactersIds);

                // Now add the teamsList to the Teams property of our EditPlayerViewModel (model)
                model.Characters = characterList;

                // Return the ViewModel
                return View(model);
            }
            else
            {
                // Else instantiate the teamsList without any pre-selected values
                MultiSelectList characterList = new MultiSelectList(db.Characters.ToList().OrderBy(i => i.CharName), "ID", "CharName");

                // Set the Teams property of the EditPlayerViewModel with the teamsList
                model.Characters = characterList;

                // Return the ViewModel
                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoryId, StoryName, CharacterIds")] EditStoryCreate model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve player from db and perform null check
                Story story = db.Stories.Find(int.Parse(model.StoryId));
                if (story == null)
                {
                    return HttpNotFound();
                }
                // Edit user name per the viewmodel
                story.StoryName = model.StoryName;

                // Check if any teams were selected by the user in the form
                if (model.CharacterIds.Count > 0)
                {
                    // First, we will instantiate a list to store each of the teams in the EditPlayerViewModel for later comparison
                    List<Character> viewModelCharacters = new List<Character>();

                    // Now, loop over each of the ids in the list of TeamIds
                    foreach (var id in model.CharacterIds)
                    {
                        // Retrive the team from the db
                        var character = db.Characters.Find(int.Parse(id));

                        if (character != null)
                        {
                            // We will add the team to our tracking list of viewmodelteams and player teams
                            try
                            {
                                story.Characters.Add(character);
                                viewModelCharacters.Add(character);
                            }
                            catch (Exception ex)
                            {
                                return View("Error", new HandleErrorInfo(ex, "Story", "Index"));
                            }
                        }
                    }
                    // Now we will create a list of all teams in the db, which we will "Except" from the new player's list
                    var allCharacters = db.Characters.ToList();
                    // Now exclude the viewModelTeams from the allTeams list to create a list of teams that we need to delete from the player
                    var charactersToRemove = allCharacters.Except(viewModelCharacters);
                    // Loop over each of the teams in our teamsToRemove List
                    foreach (var character in charactersToRemove)
                    {
                        try
                        {
                            // Remove that team from the player's Teams list
                            story.Characters.Remove(character);
                        }
                        catch (Exception ex)
                        {
                            // Catch any exceptions and error out
                            return View("Error", new HandleErrorInfo(ex, "Story", "Index"));
                        }
                    }
                }
                // Save the changes to the db
                try
                {
                    db.Entry(story).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "Story", "Indes"));
                }
                // If successfull redirect to player Details
                return RedirectToAction("Details", new { id = story.ID });
            }
            // Else something failed, return
            return View(model);
        }
        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Story story = db.Stories.Find(id);
            db.Stories.Remove(story);
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