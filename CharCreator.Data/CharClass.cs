using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Data
{
    public class CharClass
    {
        [Key]
        [ForeignKey("Character")]
        public int ID { get; set; }
        public string ClassName { get; set; }
        public bool SpellCaster { get; set; }
        public int HitPointsFirstLevel { get; set; }
        public string Proficiencies { get; set; }

        public virtual Character Character { get; set; }
    }
}
