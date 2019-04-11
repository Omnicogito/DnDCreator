using CharCreator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Models
{
    public class StoryDetail
    {
        public int ID { get; set; }
        public string StoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
    }
}
