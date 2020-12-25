﻿using System;
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
        [Required]
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
    }
}
