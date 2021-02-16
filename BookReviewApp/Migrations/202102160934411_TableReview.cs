namespace BookReviewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableReview : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Reviews", new[] { "UserId" });
            AddColumn("dbo.Reviews", "Name", c => c.String());
            DropColumn("dbo.Reviews", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "UserId", c => c.String(maxLength: 128));
            DropColumn("dbo.Reviews", "Name");
            CreateIndex("dbo.Reviews", "UserId");
            AddForeignKey("dbo.Reviews", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
