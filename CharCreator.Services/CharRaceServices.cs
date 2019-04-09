using CharCreator.Data;
using CharCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Services
{
    public class CharRaceServices
    {
       
        public bool Create(CharRaceCreate charRaceCreate)
        {
            var entity = new CharRace
            {
                RaceName = charRaceCreate.RaceName,
                Size = charRaceCreate.Size,
                Speed = charRaceCreate.Speed,
                SpecialAttributes = charRaceCreate.SpecialAttributes,
                Languages = charRaceCreate.Languages,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CharRaces.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CharRaceListItem> GetRaces()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CharRaces
                        .Select(
                            p =>
                               new CharRaceListItem
                               {
                                   ID = p.ID,
                                   RaceName = p.RaceName,
                                   Size = p.Size,
                                   Speed = p.Speed,
                                   SpecialAttributes = p.SpecialAttributes,
                                   Languages = p.Languages,
                               }
                               );

                return query.ToArray();
            }
        }

        public CharRaceDetail GetRaceById(int raceID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CharRaces
                    .Single(e => e.ID == raceID);
                return
                    new CharRaceDetail
                    {
                        RaceName = entity.RaceName,
                        Size = entity.Size,
                        Speed = entity.Speed,
                        SpecialAttributes = entity.SpecialAttributes,
                        Languages = entity.Languages,
                    };
            }
        }

        public bool UpdateRaces(CharRaceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CharRaces
                        .Single(e => e.ID == model.ID);

                entity.RaceName = model.RaceName;
                entity.Size = model.Size;
                entity.Speed = model.Speed;
                entity.SpecialAttributes = model.SpecialAttributes;
                entity.Languages = model.Languages;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRace(int raceID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CharRaces
                        .Single(e => e.ID == raceID);

                ctx.CharRaces.Remove(entity);
                return ctx.SaveChanges() == 1;


            }
        }
    }
}
