using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required, StringLength(25)]
        public string Name { get; set; }
        [Required, StringLength(25)]
        public string Surname { get; set; }
        [Required]
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public TestimonialArea TestimonialArea { get; set; }
    }
}
