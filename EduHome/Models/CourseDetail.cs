using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class CourseDetail
    {
        public int Id { get; set; }
        [Required]
        public string AboutCourse { get; set; }
        [Required]
        public string ApplyContent { get; set; }
        [Required]
        public string CertificationContent { get; set; }
        public List<Comment> Comments { get; set; }
        public CourseFeature CourseFeature { get; set; }
        [ForeignKey("CourseSimple")]
        public int CourseSimpleId { get; set; }
        public CourseSimple CourseSimple { get; set; }
    }
}
