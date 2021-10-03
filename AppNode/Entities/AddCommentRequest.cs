using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppNode.Entities
{
    public class AddCommentRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string CommentText { get; set; }
        public bool Completed { get; set; }
    }
}
