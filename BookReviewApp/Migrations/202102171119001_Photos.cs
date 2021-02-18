namespace BookReviewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Photos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reviews", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Reviews", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reviews", "ApplicationUser_Id");
            AddForeignKey("dbo.Reviews", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
