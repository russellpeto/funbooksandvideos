namespace FBVLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration003 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "orderType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItems", "orderType");
        }
    }
}
