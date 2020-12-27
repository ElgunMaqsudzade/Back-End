using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class CourseVM
    {
        public CourseSimple CourseSimple { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
