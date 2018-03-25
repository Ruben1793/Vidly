namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalAllowNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "DateRented", c => c.DateTime(nullable: true, precision: 0, storeType: "datetime2"));

        }

        public override void Down()
        {
            AlterColumn("dbo.Rentals", "DateRented", c => c.DateTime(nullable: false));

        }
    }
}
