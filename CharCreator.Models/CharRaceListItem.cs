using CharCreator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Models
{
    public class CharRaceListItem
    {
        public int ID { get; set; }
        public string RaceName { get; set; }
        public Size Size { get; set; }
        public string Speed { get; set; }
        public string SpecialAttributes { get; set; }
        public string Languages { get; set; }
    }
}
