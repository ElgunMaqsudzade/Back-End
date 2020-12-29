using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace EduHome.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public List<TagBlogSimple> TagBlogSimples { get; set; }
        public List<TagEventSimple> TagEventSimples { get; set; }
        public List<TagCourseSimple> TagCourseSimples { get; set; }
    }
}
