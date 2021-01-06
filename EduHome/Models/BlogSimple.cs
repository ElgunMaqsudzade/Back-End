using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class BlogSimple
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public int ReplyCount { get; set; }
        public bool IsDeleted { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdateTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeleteTime { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }
        public BlogDetail BlogDetail { get; set; }
        public List<Comment> Comments { get; set; }
        public List<TagBlogSimple> TagBlogSimples { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
