using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class SpeakerEventSimple
    {
        public int Id { get; set; }
        public virtual Speaker Speaker { get; set; }
        public virtual EventSimple EventSimple { get; set; }
    }
}
