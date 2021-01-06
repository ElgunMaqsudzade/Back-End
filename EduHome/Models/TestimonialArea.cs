using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class TestimonialArea
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Fullname { get; set; }
        public string Image { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdateTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeleteTime { get; set; }
    }
}
