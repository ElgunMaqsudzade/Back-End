using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class EventForCreateVM
    {
        public EventSimple EventSimple { get; set; }
        public EventDetail EventDetail { get; set; }
        public List<Speaker> Speakers { get; set; }
        public List<SpeakerEventSimple> SpeakerEventSimples { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
