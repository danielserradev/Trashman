namespace TrashCollectorProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enumdayofweek : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "pickUpDay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "pickUpDay", c => c.String(nullable: false));
        }
    }
}
