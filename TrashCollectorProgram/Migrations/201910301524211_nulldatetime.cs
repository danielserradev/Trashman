namespace TrashCollectorProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nulldatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "pickUpDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "startDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "endDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "endDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "startDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "pickUpDate", c => c.DateTime(nullable: false));
        }
    }
}
