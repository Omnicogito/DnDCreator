using CharCreator.Data;
using CharCreator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CharCreator.Services
{
    public class StoryService
    {
        public bool Create(StoryCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                MultiSelectList charList = new MultiSelectList(ctx.Characters.ToList().OrderBy(i => i.CharName), "ID", "CharName");

                model = new StoryCreate { Characters = charList };

                var story = new Story
                {
                    StoryName = model.StoryName,
                    Description = model.Description,
                };

                ctx.Stories.Add(story);
                return ctx.SaveChanges() == 1;
            }

            //foreach (int i in model.Characters)
            //{
            //    story.Characters = ctx.Characters.Where(o => o.ID == i).ToList();
            //}




            //var allCharacterList = ctx.Characters.Include(t => t.Stories).ToList();
            //story.Characters = (List<Character>)allCharacterList.Where(o => o.ID == model);

            //var allCharacterList = ctx.Characters.ToList();
            //entity.Characters = allCharacterList.Where(o => o.ID == id);

            //using (var ctx = new ApplicationDbContext())
            //{
            //    foreach(Character character in storyCreate.Characters)
            //    {
            //       entity.Characters.Add(character);
            // }

            //  ctx.Stories.Add(entity);

            //using (var ctx = new ApplicationDbContext())
            //{
            //    var story = ctx.Stories
            //    .Include(p => p.Characters)
            //    .Single(p => p.ID == entity.ID);
            //    var newCharacter = ctx.Characters.Find(entity.ID);

            //    story.Characters.Add(new Character
            //    {
            //        Stories = story,
            //        Character = newCharacter,
            //   });
            //}
            //return ctx.SaveChanges() == 1;
        }

        //public IEnumerable<StoryListItem> GetStories()
        //{
        //    //using (var ctx = new ApplicationDbContext())
        //    //{
        //    //    var query = ctx.Stories.Select(
        //    //                p =>
        //    //                   new StoryListItem
        //    //                   {
        //    //                       ID = p.ID,
        //    //                       StoryName = p.StoryName,
        //    //                       Description = p.Description,
        //    //                       Characters = p.Characters,
        //    //                   }
        //    //                   );

        //    //    return query.ToArray();
        //    //}

        //    //using (var ctx = new ApplicationDbContext())
        //    //{
        //    //    var query = ctx.Stories.ToList().OrderBy(i => i.StoryName);
        //    //    return query;
        //    //}
        //}

        public StoryDetail GetStorybyID(int? storyID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Stories
                    .Single(e => e.ID == storyID);
                return
                    new StoryDetail
                    {
                        ID = entity.ID,
                        StoryName = entity.StoryName,
                        Description = entity.Description,
                        Characters = entity.Characters,
                    };
            }
        }

        public bool UpdateStory(StoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stories
                        .Single(e => e.ID == model.ID);

                entity.Description = model.Description;
                entity.StoryName = model.StoryName;
                entity.Characters = model.Characters;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteStory(int storyID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stories
                        .Single(e => e.ID == storyID);

                ctx.Stories.Remove(entity);
                return ctx.SaveChanges() == 1;


            }
        }
    }
}
