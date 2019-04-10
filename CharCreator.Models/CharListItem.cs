using CharCreator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Models
{
    public class CharListItem
    {
        public int ID { get; set; }
        [Display(Name = "Character Name")]
        public string CharName { get; set; }
        [Display(Name = "Race")]
        public string CharRaceID { get; set; }
        [Display(Name = "Class")]
        public string CharClassID { get; set; }
        public Alignment Alignment { get; set; }
        public Background Background { get; set; }
        [Display(Name = "History")]
        public string CharHistory { get; set; }
        [Display(Name = "Experience Points")]
        public int ExperiencePoints { get; set; }
        public string Traits { get; set; }
        public int Level { get; set; }
    }
}
