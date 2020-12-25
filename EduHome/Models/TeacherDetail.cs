using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class TeacherDetail
    {
        public int Id { get; set; }
        [Required]
        public string AboutContent { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public int Experience { get; set; }
        public string Hobbies { get; set; }
        [Required]
        public string Faculty { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Skype { get; set; }
        [ForeignKey("TeacherSimple")]
        public int TeacherSimpleId { get; set; }
        public TeacherSimple TeacherSimple { get; set; }
        public List<TeacherSkill> TeacherSkills { get; set; }
    }
}
