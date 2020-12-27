using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class CourseFeature
    {
        public int Id { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime? StartingTime { get; set; }
        [Required]
        public int CourseDuration { get; set; }
        [Required]
        public int ClassDuration { get; set; }
        [Required]
        public string SkillLevel { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public int StudentCount { get; set; }
        [Required]
        public string Assesment { get; set; }
        [Required]
        public double Price { get; set; }
        [ForeignKey("CourseDetail")]
        public int CourseDetailId { get; set; }
        public CourseDetail CourseDetail { get; set; }
    }
}
