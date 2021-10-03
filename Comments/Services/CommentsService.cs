using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comments.Models;
using RestSharp;

namespace Comments.Services
{
    public class CommentsService
    {
        private readonly string _connectionUrl = "https://localhost:5001/comments/add";

        public IRestResponse<IRestResponse> AddComment(Models.Comments comment) 
        {
            var client = new RestClient(_connectionUrl);
            var request = new Entities.AddCommentRequest()
            {
                UserName = comment.UserName,
                CommentText = comment.Comment
            };

            var requestSharp = new RestRequest(Method.POST);
            requestSharp.AddJsonBody(request);
            var response = client.Post<IRestResponse>(requestSharp);
            return response;
        }

        private void Send()
        {

        }
    }
}
