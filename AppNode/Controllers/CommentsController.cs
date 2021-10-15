using AppNode.Entities;
using AppNode.Models;
using AppNode.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace AppNode.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
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
            => _dbService.GetComments();

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                _dbService.DeleteComment(id);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("Exception: " + e.Message.ToString());
                return false;
            }
        }

        [HttpPost]
        public bool AddPost([FromBody] AddCommentRequest request)
        {
            try
            {
                _dbService.AddComment(request.UserName, request.CommentText);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("Exception: " + e.Message.ToString());
                return false;
            }
        }
    }
}
