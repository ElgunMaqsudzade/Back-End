using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class TagBlogSimple
    {
        public int Id { get; set; }
        public  int TagId { get; set; }
        public  Tag Tag { get; set; }
        public  int BlogSimpleId { get; set; }
        public  BlogSimple BlogSimple { get; set; }
    }
}
