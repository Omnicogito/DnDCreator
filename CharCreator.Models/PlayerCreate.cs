using CharCreator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Models
{
    public class PlayerCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter more than two characters")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field")]
        public string Name { get; set; }
        public int Age { get; set; }
        [MaxLength(100)]
        public string Location { get; set; }
        public ExperienceLevel Experience { get; set; }
        public override string ToString() => Name;
    }
}
