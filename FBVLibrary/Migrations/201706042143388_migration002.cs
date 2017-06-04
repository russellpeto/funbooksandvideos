namespace FBVLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "mediaItemType", c => c.Int());
            AddColumn("dbo.OrderItems", "membershipType", c => c.Int());
            DropColumn("dbo.OrderItems", "type");
            DropColumn("dbo.OrderItems", "type1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "type1", c => c.Int());
            AddColumn("dbo.OrderItems", "type", c => c.Int());
            DropColumn("dbo.OrderItems", "membershipType");
            DropColumn("dbo.OrderItems", "mediaItemType");
        }
    }
}
