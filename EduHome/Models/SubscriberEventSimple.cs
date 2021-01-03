using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class SubscriberEventSimple
    {
        public int Id { get; set; }
        public  int SubscriberId { get; set; }
        public virtual Subscriber Subscriber { get; set; }
        public int  EventSimpleId { get; set; }
        public virtual EventSimple EventSimple { get; set; }
    }
}
