using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class EventDetail
    {
        public int Id { get; set; }
        [Required]
        public string AboutContent { get; set; }
        [ForeignKey("EventSimple")]
        public int EventSimpleId { get; set; }
        public EventSimple EventSimple { get; set; }
    }
}
