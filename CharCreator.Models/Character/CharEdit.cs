﻿using CharCreator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharCreator.Models
{
    public class CharEdit
    {
        public int ID { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter more than two characters")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field")]
        [Display(Name = "Name")]
        public string CharName { get; set; }
        public Guid UserID { get; set; }
        [Display(Name ="Class")]
        public int CharClassID { get; set; }
        public Alignment Alignment { get; set; }
        [Display(Name ="History")]
        public string CharHistory { get; set; }
        public int ExperiencePoints { get; set; }
        public string Traits { get; set; }
        public int Level { get; set; }
    }
}
