using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class HeaderFooter
    {
        public int Id { get; set; }
        public string Content { get; set; }
        [Required]
        public string Logo { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }

    }
}
