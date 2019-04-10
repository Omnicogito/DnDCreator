﻿using CharCreator.Data;
using CharCreator.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CharCreator.Services
{
    public class CharService
    {

        private readonly Guid _userId;

        public CharService(Guid userId)
        {
            _userId = userId;
        }
        public bool Create(CharCreate charCreate)
        {

            var entity = new Character
            {
                CharName = charCreate.CharName,
                CharRaceID = charCreate.CharRaceID,
                CharClassID = charCreate.CharClassID,
                UserID = _userId,
                Alignment = charCreate.Alignment,
                Background = charCreate.Background,
                CharHistory = charCreate.CharHistory,
                ExperiencePoints = charCreate.ExperiencePoints,
                Traits = charCreate.Traits,
                Level = charCreate.Level,
            };


            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CharListItem> GetCharacters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Characters
                        .Where(p => p.UserID == _userId)
                        .Select(
                            p =>
                               new CharListItem
                               {
                                   ID = p.ID,
                                   CharName = p.CharName,
                                   CharRaceID = p.CharRaceID,
                                   CharClassID = p.CharClassID,
                                   Alignment = p.Alignment,
                                   Background = p.Background,
                                   CharHistory = p.CharHistory,
                                   ExperiencePoints = p.ExperiencePoints,
                                   Traits = p.Traits,
                                   Level = p.Level,
                               }
                               );

                return query.ToArray();
            }
        }

        public CharDetail GetCharacterById(int? charID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Characters
                    .Single(e => e.ID == charID && e.UserID == _userId);
                return
                    new CharDetail
                    {
                        CharName = entity.CharName,
                        CharRaceID = entity.CharRaceID,
                        CharClassID = entity.CharClassID,
                        Alignment = entity.Alignment,
                        Background = entity.Background,
                        CharHistory = entity.CharHistory,
                        ExperiencePoints = entity.ExperiencePoints,
                        Traits = entity.Traits,
                        Level = entity.Level,
                    };
            }
        }

        public bool UpdateCharacter(CharEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.ID == model.ID && e.UserID == _userId);

                entity.Alignment = model.Alignment;
                entity.ExperiencePoints = model.ExperiencePoints;
                entity.CharHistory = model.CharHistory;
                entity.Level = model.Level;
                entity.CharClassID = model.CharClassID;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCharacter(int charID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.ID == charID && e.UserID == _userId);

                ctx.Characters.Remove(entity);
                return ctx.SaveChanges() == 1;


            }
        }
    }
}
