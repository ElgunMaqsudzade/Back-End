using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class SidebarVM
    {
        public List<BlogSimple> BlogSimples { get; set; }
        public List<CourseSimple> CourseSimples { get; set; }
        public List<EventSimple> EventSimples { get; set; }
        public List<Category> Categories { get; set; }
    }
}
