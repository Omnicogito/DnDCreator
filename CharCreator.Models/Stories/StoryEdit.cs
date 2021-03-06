﻿using CharCreator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CharCreator.Models
{
    public class StoryEdit
    {
        public int ID { get; set; }
        public string StoryId { get; set; }
        public string StoryName { get; set; }
        public string Description { get; set; }
        public List<string> CharacterIds { get; set; }
        public MultiSelectList Characters { get; set; }
    }
}
