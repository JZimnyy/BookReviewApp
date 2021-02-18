namespace BookReviewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "Photo", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.Books", "Cover", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Cover", c => c.String());
            AlterColumn("dbo.Books", "ISBN", c => c.String(maxLength: 13));
            AlterColumn("dbo.Books", "Description", c => c.String());
            AlterColumn("dbo.Books", "Title", c => c.String());
            AlterColumn("dbo.Authors", "Photo", c => c.String());
            AlterColumn("dbo.Authors", "Description", c => c.String());
            AlterColumn("dbo.Authors", "Surname", c => c.String());
            AlterColumn("dbo.Authors", "Name", c => c.String());
        }
    }
}
