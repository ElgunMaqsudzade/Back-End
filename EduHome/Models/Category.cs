using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(15)]
        public string Name { get; set; }
        public List<EventSimple> EventSimples { get; set; }
        public List<CourseSimple> CourseSimples { get; set; }
        public List<BlogSimple> BlogSimples { get; set; }
    }
}
