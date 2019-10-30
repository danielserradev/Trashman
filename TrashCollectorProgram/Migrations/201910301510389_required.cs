namespace TrashCollectorProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "firstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "lastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "streetAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "city", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "stateCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "stateCode", c => c.String());
            AlterColumn("dbo.Customers", "city", c => c.String());
            AlterColumn("dbo.Customers", "streetAddress", c => c.String());
            AlterColumn("dbo.Customers", "lastName", c => c.String());
            AlterColumn("dbo.Customers", "firstName", c => c.String());
        }
    }
}
