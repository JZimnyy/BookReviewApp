namespace BookReviewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ISBNupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false, maxLength: 13));
        }
    }
}
