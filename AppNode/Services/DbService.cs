using AppNode.Models;
using System.Collections.Generic;
using System.Linq;

namespace AppNode.Services
{
    public class DbService : IDbService
    {
        private readonly CommentsContext _context;

        public DbService(CommentsContext context)
        {
            _context = context;
        }

        public IEnumerable<Comments> GetComments()
            => _context.Comments.ToList();

        public void AddComment(string userName, string commentText)
        {
            var comment = new Comments()
            {
                UserName = userName,
                CommentText = commentText
            };
            _context.Comments.Add(comment);

            _context.SaveChanges();
        }

        public void DeleteComment(int commentId)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == commentId);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }

        }
    }
}
