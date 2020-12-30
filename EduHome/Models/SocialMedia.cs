using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int? TeacherSimpleId { get; set; }
        public virtual TeacherSimple TeacherSimple { get; set; }
        public int? HeaderFooterId { get; set; }
        public virtual HeaderFooter HeaderFooter { get; set; }
    }
}
