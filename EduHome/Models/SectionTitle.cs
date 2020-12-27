using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class SectionTitle
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string IconImage { get; set; }
    }
}
