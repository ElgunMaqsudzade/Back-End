using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class CourseSimple
    {
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string Title { get; set; }
        [Required]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required]
        public string MainContent { get; set; }
        [Required]
        public bool IsSimple { get; set; }
        public bool IsDeleted { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdateTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeleteTime { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }
        public CourseDetail CourseDetail { get; set; }
        public List<Comment> Comments { get; set; }
        public List<TagCourseSimple> TagCourseSimples { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
