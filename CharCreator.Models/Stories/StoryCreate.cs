﻿using CharCreator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Models
{
    public class StoryCreate
    {
        public string StoryName { get; set; }
        public string Description { get; set; }
        public virtual List<int> Characters { get; set; }

        public virtual IEnumerable<Character> Character { get; set; }
    }
}
