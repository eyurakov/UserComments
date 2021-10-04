namespace AppNode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datacheck : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "UserName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Comments", "CommentText", c => c.String(nullable: false, maxLength: 254));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "CommentText", c => c.String());
            AlterColumn("dbo.Comments", "UserName", c => c.String());
        }
    }
}
