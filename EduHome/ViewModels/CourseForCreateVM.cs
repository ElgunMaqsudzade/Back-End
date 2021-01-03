using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class CourseForCreateVM
    {
        public CourseSimple CourseSimple { get; set; }
        public CourseFeature CourseFeature { get; set; }
        public CourseDetail CourseDetail { get; set; }
        public List<Tag> Tags { get; set; }
        public List<TagCourseSimple> TagCourseSimples { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
    }
}
