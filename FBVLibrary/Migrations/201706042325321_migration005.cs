namespace FBVLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration005 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseOrderItems", "shortDescription", c => c.String());
            AddColumn("dbo.PurchaseOrderItems", "fullDescription", c => c.String());
            AddColumn("dbo.PurchaseOrderItems", "unitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PurchaseOrderItems", "orderItemType", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseOrderItems", "startDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PurchaseOrderItems", "endDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.OrderItems", "mediaItemType");
            DropColumn("dbo.OrderItems", "membershipType");
            DropColumn("dbo.OrderItems", "startDate");
            DropColumn("dbo.OrderItems", "endDate");
            DropColumn("dbo.OrderItems", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.OrderItems", "endDate", c => c.DateTime());
            AddColumn("dbo.OrderItems", "startDate", c => c.DateTime());
            AddColumn("dbo.OrderItems", "membershipType", c => c.Int());
            AddColumn("dbo.OrderItems", "mediaItemType", c => c.Int());
            DropColumn("dbo.PurchaseOrderItems", "endDate");
            DropColumn("dbo.PurchaseOrderItems", "startDate");
            DropColumn("dbo.PurchaseOrderItems", "orderItemType");
            DropColumn("dbo.PurchaseOrderItems", "unitPrice");
            DropColumn("dbo.PurchaseOrderItems", "fullDescription");
            DropColumn("dbo.PurchaseOrderItems", "shortDescription");
        }
    }
}
