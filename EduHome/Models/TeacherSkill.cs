﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class TeacherSkill
    {
        public int Id { get; set; }
        public int TeacherSimpleId { get; set; }

        public TeacherSimple TeacherSimple { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        [Required, Range(0, 100)]
        public int SkillValue { get; set; }
    }
}
