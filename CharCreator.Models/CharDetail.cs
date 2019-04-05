using CharCreator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Models
{
    class CharDetail
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter more than two characters")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field")]
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
