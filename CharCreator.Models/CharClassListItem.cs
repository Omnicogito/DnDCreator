using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Models
{
    public class CharClassListItem
    {
        public int ID { get; set; }
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }
        public bool SpellCaster { get; set; }
        [Display(Name = "Hit Points")]
        public int HitPointsFirstLevel { get; set; }
        public string Proficiencies { get; set; }
    }
}
