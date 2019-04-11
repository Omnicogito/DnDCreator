using CharCreator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Models
{
    public class CharRaceListItem
    {
        public int ID { get; set; }
        [Display(Name = "Race")]
        public string RaceName { get; set; }
        public Size Size { get; set; }
        public string Speed { get; set; }
        [Display(Name = "Special Attributes")]
        public string SpecialAttributes { get; set; }
        public string Languages { get; set; }
    }
}
