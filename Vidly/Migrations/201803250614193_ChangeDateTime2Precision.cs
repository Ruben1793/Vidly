namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTime2Precision : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "DateRented", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));

        }

        public override void Down()
        {
            AlterColumn("dbo.Rentals", "DateRented", c => c.DateTime(nullable: false));

        }
    }
}
