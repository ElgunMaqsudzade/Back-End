using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class EventSimple
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Title { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartingTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndingTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdateTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeleteTime { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }
        public EventDetail EventDetail { get; set; }
        public List<Comment> Comments { get; set; }
        public List<SpeakerEventSimple> SpeakerEventSimples { get; set; }
        public List<TagEventSimple> TagEventSimples { get; set; }
    }
}
