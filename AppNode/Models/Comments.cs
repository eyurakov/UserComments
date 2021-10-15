using System.ComponentModel.DataAnnotations;

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
        [MinLength(5)]
        [MaxLength(254)]
        public string CommentText { get; set; }
    }
}
