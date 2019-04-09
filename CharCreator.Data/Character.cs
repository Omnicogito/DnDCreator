﻿using System;
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
        LawfulGood, NeutralGood, ChaoticGood, LawfulNeutral, TrueNeutral, ChaoticNeutral, LawfulEvil, NeutralEvil, ChaoticEvil
    };

    public enum Background
    {
        Acolyte, CriminalSpy, FolkHero, Noble, Sage, Soldier
    };
    public class Character
    {
        [Key]
        public int ID { get; set; }
        public int CharRaceID { get; set; }
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
