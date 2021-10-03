using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Comments.Services;

namespace Comments.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class CommentsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly CommentsService _commentsService;
            public CommentsController(IConfiguration configuration, CommentsService commentsService)
        {
            _configuration = configuration;
            _commentsService = commentsService;
        }

        public ActionResult Index()
        {
           
            return View("Comments");
        }
      
        public ActionResult Save(Comments.Models.Comments comments)
        {
            var response = _commentsService.AddComment(comments);
           // if (response.IsSuccessful)
            return View("Comments");
           
        }
            
    }
}
