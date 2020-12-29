using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class TagEventSimple
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int EventSimpleId { get; set; }
        public EventSimple EventSimple { get; set; }
    }
}
