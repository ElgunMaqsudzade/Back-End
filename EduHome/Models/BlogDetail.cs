using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class BlogDetail
    {
        public int Id { get; set; }
        [Required]
        public string AboutContent { get; set; }
        [ForeignKey("BlogSimple")]
        public int BlogSimpleId { get; set; }
        public BlogSimple BlogSimple { get; set; }
    }
}
