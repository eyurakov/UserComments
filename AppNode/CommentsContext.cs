using AppNode.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AppNode
{
    public class CommentsContext : DbContext
    {
        public CommentsContext()
            : base("DbConnection")
        { }

        public DbSet<Comments> Comments { get; set; }
    }
}