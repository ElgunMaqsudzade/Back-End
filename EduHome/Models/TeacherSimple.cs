using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class TeacherDetail
    {
        public int Id { get; set; }
        [Required]
        public string AboutContent { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public int Experience { get; set; }
        public string Hobbies { get; set; }
        [Required]
        public string Faculty { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Skype { get; set; }
        [Required,Range(0,100)]
        public int Language { get; set; }
        [Required,Range(0,100)]
        public int Design { get; set; }
        [Required,Range(0,100)]
        public int TeamLeader { get; set; }
        [Required,Range(0,100)]
        public int Innovation { get; set; }
        [Required,Range(0, 100)]
        public int Development { get; set; }
        [Required,Range(0,100)]
        public int Comunication { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdateTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeleteTime { get; set; }
        [Required,DataType(DataType.DateTime)]
        public DateTime? CreateTime { get; set; }
        public int TeacherSimpleRef { get; set; }
        public TeacherSimple TeacherSimple { get; set; }
    }
}
