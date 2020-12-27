using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeleteTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdateTime { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }
        public int? ProfessionId { get; set; }
        public virtual Profession Profession { get; set; }
        public  List<SpeakerEventSimple> SpeakerEventSimples { get; set; }
    }
}
