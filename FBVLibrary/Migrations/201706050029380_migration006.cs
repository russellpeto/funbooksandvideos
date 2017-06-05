namespace FBVLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration006 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PurchaseOrderItems", newName: "LineItems");
            DropPrimaryKey("dbo.LineItems");
            DropColumn("dbo.LineItems", "purchaseOrderItemID");
            DropColumn("dbo.MembershipEntries", "purchaseOrderItemID");
            AddColumn("dbo.MembershipEntries", "lineItemID", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseOrders", "customerID", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseOrders", "purchaseOrderStatus", c => c.Int(nullable: false));
            AddColumn("dbo.LineItems", "lineItemID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.LineItems", "lineItemID");
            CreateIndex("dbo.MembershipEntries", "customerID");
            AddForeignKey("dbo.MembershipEntries", "customerID", "dbo.Customers", "customerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.LineItems");
            DropColumn("dbo.LineItems", "lineItemID");
            AddColumn("dbo.LineItems", "purchaseOrderItemID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.MembershipEntries", "purchaseOrderItemID", c => c.Int(nullable: false));
            DropForeignKey("dbo.MembershipEntries", "customerID", "dbo.Customers");
            DropIndex("dbo.MembershipEntries", new[] { "customerID" });
            DropColumn("dbo.PurchaseOrders", "purchaseOrderStatus");
            DropColumn("dbo.PurchaseOrders", "customerID");
            DropColumn("dbo.MembershipEntries", "lineItemID");
            AddPrimaryKey("dbo.LineItems", "purchaseOrderItemID");
            RenameTable(name: "dbo.LineItems", newName: "PurchaseOrderItems");
        }
    }
}
