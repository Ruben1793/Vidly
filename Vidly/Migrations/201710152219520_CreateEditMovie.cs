namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEditMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movies", "RealeaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "RealeaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
