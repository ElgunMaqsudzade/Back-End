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
    }
}
