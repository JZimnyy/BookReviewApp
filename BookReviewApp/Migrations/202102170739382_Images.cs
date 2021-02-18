namespace BookReviewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Images : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Photo", c => c.String());
            AddColumn("dbo.Books", "Cover", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Cover");
            DropColumn("dbo.Authors", "Photo");
        }
    }
}
