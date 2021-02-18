namespace BookReviewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewRange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "Name", c => c.String());
        }
    }
}
