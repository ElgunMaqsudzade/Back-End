using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeleteTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdateTime { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }
        public int? BlogSimpleId { get; set; }
        public virtual BlogSimple BlogSimple { get; set; }
        public int? CourseSimpleId { get; set; }
        public virtual CourseSimple CourseSimple { get; set; }
        public int? EventSimpleId { get; set; }
        public virtual EventSimple EventSimple { get; set; }
    }
}
