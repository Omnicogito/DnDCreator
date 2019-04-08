using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Data
{
    public enum Alignment
    {
        LawfulGood, NeutralGood, ChaoticGood, LawfulNeutral, TrueNeutral, ChaoticNeutral, LawfulEvil, NeutralEvil, ChaoticEvil
    };

    public enum Background
    {
        Acolyte, CriminalSpy, FolkHero, Noble, Sage, Soldier
    };
    public class Character
    {
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public string CharName { get; set; }
        public int CharRaceID { get; set; }
        public int CharClassID { get; set; }
        public Alignment Alignment { get; set; }
        public Background Background { get; set; }
        public string CharHistory { get; set; }
        public int ExperiencePoints { get; set; }
        public string Traits { get; set; }
        public int Level { get; set; }

        public virtual ICollection<Story> Stories { get; set; }
    }
}
