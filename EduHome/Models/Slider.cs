﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required, StringLength(25)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string BgImage { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}