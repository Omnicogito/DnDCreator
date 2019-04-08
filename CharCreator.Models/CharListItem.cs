using CharCreator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Models
{
    public class CharListItem
    {
        public int ID { get; set; }
        public string CharName { get; set; }
        public int CharRaceID { get; set; }
        public int CharClassID { get; set; }
        public Alignment Alignment { get; set; }
        public Background Background { get; set; }
        public string CharHistory { get; set; }
        public int ExperiencePoints { get; set; }
        public string Traits { get; set; }
        public int Level { get; set; }
    }
}
