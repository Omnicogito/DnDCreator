using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Data
{
    public enum Alignment
    {
        [Display(Name = "Lawful Good")]
        LawfulGood,
        [Display(Name = "Neutral Good")]
        NeutralGood,
        [Display(Name = "Chaotic Good")]
        ChaoticGood,
        [Display(Name = "Lawful Neutral")]
        LawfulNeutral,
        [Display(Name = "True Neutral")]
        TrueNeutral,
        [Display(Name = "Chaotic Neutral")]
        ChaoticNeutral,
        [Display(Name = "Lawful Evil")]
        LawfulEvil,
        [Display(Name = "Neutral Evil")]
        NeutralEvil,
        [Display(Name = "Chaotic Evil")]
        ChaoticEvil
    };

    public enum Background
    {
        Acolyte,
        [Display(Name = "Criminal/Spy")]
        CriminalSpy,
        [Display(Name = "Folk Hero")]
        FolkHero,
        Noble,
        Sage,
        Soldier
    };
    public class Character
    {
        public Character()
        {
            Stories = new HashSet<Story>();
        }
        [Key]
        public int ID { get; set; }
        [Display(Name ="Race")]
        public int CharRaceID { get; set; }
        [Display(Name ="Class")]
        public int CharClassID { get; set; }
        public Guid UserID { get; set; }
        [Display(Name ="Name")]
        public string CharName { get; set; }
        public Alignment Alignment { get; set; }
        public Background Background { get; set; }
        [Display(Name ="Character History")]
        public string CharHistory { get; set; }
        [Display(Name ="Experience Points")]
        public int ExperiencePoints { get; set; }
        public string Traits { get; set; }
        public int Level { get; set; }

        public virtual ICollection<Story> Stories { get; set; }
    }
}
