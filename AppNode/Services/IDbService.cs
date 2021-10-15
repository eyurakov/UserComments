using AppNode.Models;
using System.Collections.Generic;

namespace AppNode.Services
{
    public interface IDbService
    {
        public IEnumerable<Comments> GetComments();

        public void AddComment(string userName, string commentText);

        public void DeleteComment(int commentId);
    }
}
