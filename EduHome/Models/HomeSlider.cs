using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class HomeSlider
    {
        public int Id { get; set; }
        [Required, StringLength(25)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string BgImage { get; set; }
    }
}
