using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppNode.Models
{
    public class Comments
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string UserName { get; set; }

        [Required]
        [MinLength(15)]
        [MaxLength(254)]
        public string CommentText { get; set; }
    }
}
