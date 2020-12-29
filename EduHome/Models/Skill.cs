﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Skill
    {
        public int Id { get; set; }
        [Required, StringLength(15)]
        public string Name { get; set; }
        [Required, Range(0, 100)]
        public int Value { get; set; }
        public List<TeacherSkill> TeacherSkills { get; set; }
    }
}