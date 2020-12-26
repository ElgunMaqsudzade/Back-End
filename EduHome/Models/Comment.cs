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
        public int BlogDetailId { get; set; }
        public virtual BlogDetail BlogDetail { get; set; }
    }
}
