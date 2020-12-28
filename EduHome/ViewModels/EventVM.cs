using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class EventVM
    {
        public EventSimple EventSimple { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
