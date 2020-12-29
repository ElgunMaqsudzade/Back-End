using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class TeacherSkill
    {
        public int Id { get; set; }
        public int TeacherDetailId { get; set; }

        public TeacherDetail TeacherDetail { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
