using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comments.Entities
{
    public class AddCommentRequest
    {
        public string UserName { get; set; }
        public string CommentText { get; set; }
    }
}
