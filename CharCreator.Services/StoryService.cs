using CharCreator.Data;
using CharCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Services
{
    public class StoryService
    {
        public bool Create(StoryCreate storyCreate)
        {
            var entity = new Story
            {
                StoryName = storyCreate.StoryName,
                Description = storyCreate.StoryName,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Stories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<StoryListItem> GetStories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Stories
                        .Select(
                            p =>
                               new StoryListItem
                               {
                                   ID = p.ID,
                                   StoryName = p.StoryName,
                                   Description = p.Description,
                               }
                               );

                return query.ToArray();
            }
        }

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
