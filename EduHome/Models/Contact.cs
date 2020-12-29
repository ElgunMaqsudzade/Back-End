using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required,StringLength(25)]
        public string Title { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
