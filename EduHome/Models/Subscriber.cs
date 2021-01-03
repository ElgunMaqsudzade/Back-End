using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        [Required]
        public string Mail { get; set; }
        public List<SubscriberEventSimple> SubscriberEventSimples { get; set; }
    }
}
