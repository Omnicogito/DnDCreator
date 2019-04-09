using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Data
{
    public class Story
    {
        public int ID { get; set; }
        [Display(Name ="Story Name")]
        public string StoryName { get; set; }
        public virtual ICollection<Character> Characters { get; set; }

    }
}
