using AppNode.Entities;
using AppNode.Models;
using AppNode.Services;
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
        private readonly IDbService _dbService;

        public CommentsController(ILogger<CommentsController> logger, IDbService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }

        [HttpGet]
        public IEnumerable<Comments> GetComments()
        {
            return _dbService.GetComments();
        }

        
        [HttpGet]
        public bool Add(string userName, string commentText)
        {
            try
            {
                _dbService.AddComment(userName, commentText);
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError("Exception: " + e);
                return false;
            }
        }

        [HttpGet]
        public void Delete(int commentId)
        {
            _dbService.DeleteComment(commentId);
        }
    }
}
