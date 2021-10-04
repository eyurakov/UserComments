using AppNode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppNode.Services
{
    public interface IDbService
    {
        public IEnumerable<Comments> GetComments();
        public void AddComment(string userName, string commentText);
        public void DeleteComment(int commentId);
    }
}
