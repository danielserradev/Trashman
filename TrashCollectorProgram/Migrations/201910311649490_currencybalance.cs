namespace TrashCollectorProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class currencybalance : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "balance", c => c.Double(nullable: false));
        }
    }
}
