using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Profession
    {
        public int Id { get; set; }
        [Required, StringLength(25)]
        public string Name { get; set; }
        public List<TeacherSimple> TeacherSimples { get; set; }
        public List<Speaker> Speakers { get; set; }
    }
}
