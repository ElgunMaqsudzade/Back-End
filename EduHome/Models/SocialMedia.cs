using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class SocialMedia
    {
        public int Id { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeleteTime { get; set; }
        public int TeacherSimpleRef { get; set; }
        public TeacherSimple TeacherSimple { get; set; }
    }
}
