using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class TeacherForCreateVM
    {
        public TeacherSimple TeacherSimple { get; set; }
        public Profession Profession { get; set; }
        public List<Profession> Professions { get; set; }
        public TeacherDetail TeacherDetail { get; set; }
        public List<TeacherSkill> TeacherSkills { get; set; }
        public List<Skill> Skills { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
    }
}
