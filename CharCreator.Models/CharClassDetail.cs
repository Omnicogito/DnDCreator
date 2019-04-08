using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Models
{
    public class CharClassDetail
    {
        public string ClassName { get; set; }
        public bool SpellCaster { get; set; }
        public int HitPointsFirstLevel { get; set; }
        public string Proficiencies { get; set; }
    }
}
