using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class BlogForCreateVM
    {
        public BlogSimple BlogSimple { get; set; }
        public BlogDetail BlogDetail { get; set; }
        public List<Tag> Tags { get; set; }
        public List<TagBlogSimple> TagBlogSimples { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
    }
}
