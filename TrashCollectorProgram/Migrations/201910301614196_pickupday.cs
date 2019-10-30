namespace TrashCollectorProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pickupday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "pickUpDay", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "pickUpDay");
        }
    }
}
