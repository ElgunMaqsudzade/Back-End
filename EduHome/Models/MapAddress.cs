﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class MapAddress
    {
        public int Id { get; set; }
        [Required]
        public string Iframe { get; set; }
    }
}
