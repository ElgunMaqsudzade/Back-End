﻿using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class BlogVM
    {
        public BlogSimple BlogSimple { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
