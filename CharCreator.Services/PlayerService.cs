using CharacterCreator.Models;
using CharCreator.Data;
using CharCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Services
{
    public class PlayerService
    {
        public bool Create(PlayerCreate player)
        {
            var entity = new Player
            {
                Name = player.Name,
                Age = player.Age,
                Location = player.Location,
                ExperienceLevel = player.Experience,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Players.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
