using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class TeacherSimple
    {
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string Fullname { get; set; }
        [Required]
        public bool IsSimple { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdateTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeleteTime { get; set; }
        [Required,DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }
        public TeacherDetail TeacherDetail { get; set; }
        [Required]
        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
    }
}
