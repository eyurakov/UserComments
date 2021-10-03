using AppNode.Entities;
using AppNode.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppNode.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CommentsController : ControllerBase
    {
        

        private readonly ILogger<CommentsController> _logger;
        private readonly CommentsContext _context;

        public CommentsController(ILogger<CommentsController> logger, CommentsContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Comments> GetComments()
        {
            //not implemented
            return _context.Comments.ToList();
        }

        
        [HttpPost]
        public string Add([FromBody] AddCommentRequest request)
        {
            _context.Comments.Add(new Comments() { 
                UserName = request.UserName,
                CommentText = request.CommentText
            });

            _context.SaveChanges();

            return "Success";
        }
    }
}
