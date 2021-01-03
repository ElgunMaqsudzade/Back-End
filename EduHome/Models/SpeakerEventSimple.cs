using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class SpeakerEventSimple
    {
        public int Id { get; set; }
        public  int SpeakerId { get; set; }
        public virtual Speaker Speaker { get; set; }
        public int  EventSimpleId { get; set; }
        public virtual EventSimple EventSimple { get; set; }
    }
}
