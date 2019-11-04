namespace TrashCollectorProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latlong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "lat", c => c.Single(nullable: false));
            AddColumn("dbo.Customers", "lng", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "lng");
            DropColumn("dbo.Customers", "lat");
        }
    }
}
