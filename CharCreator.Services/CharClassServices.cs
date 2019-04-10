using CharCreator.Data;
using CharCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Services
{
    public class CharClassServices
    {
        public bool Create(CharClassCreate charClassCreate)
        {
            var entity = new CharClass
            {
                ClassName = charClassCreate.ClassName,
                SpellCaster = charClassCreate.SpellCaster,
                HitPointsFirstLevel = charClassCreate.HitPointsFirstLevel,
                Proficiencies = charClassCreate.Proficiencies,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CharClasses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CharClassListItem> GetClasses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CharClasses
                        .Select(
                            p =>
                               new CharClassListItem
                               {
                                   ID = p.ID,
                                   ClassName = p.ClassName,
                                   SpellCaster = p.SpellCaster,
                                   HitPointsFirstLevel = p.HitPointsFirstLevel,
                                   Proficiencies = p.Proficiencies,
                               }
                               );

                return query.ToArray();
            }
        }

        public CharClassDetail GetClassById(int? classID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CharClasses
                    .Single(e => e.ID == classID);
                return
                    new CharClassDetail
                    {
                        ID = entity.ID,
                        ClassName = entity.ClassName,
                        SpellCaster = entity.SpellCaster,
                        HitPointsFirstLevel = entity.HitPointsFirstLevel,
                        Proficiencies = entity.Proficiencies,
                    };
            }
        }

        public bool UpdateClass(CharClassEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CharClasses
                        .Single(e => e.ID == model.ID);

                entity.ClassName = model.ClassName;
                entity.SpellCaster = model.SpellCaster;
                entity.HitPointsFirstLevel = model.HitPointsFirstLevel;
                entity.Proficiencies = model.Proficiencies;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteClass(int classID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CharClasses
                        .Single(e => e.ID == classID);

                ctx.CharClasses.Remove(entity);
                return ctx.SaveChanges() == 1;


            }
        }
    }
}
