namespace FBVLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration004 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "PurchaseOrder_purchaseOrderID", "dbo.PurchaseOrders");
            DropIndex("dbo.OrderItems", new[] { "PurchaseOrder_purchaseOrderID" });
            CreateTable(
                "dbo.PurchaseOrderItems",
                c => new
                    {
                        purchaseOrderItemID = c.Int(nullable: false, identity: true),
                        orderItemID = c.Int(nullable: false),
                        PurchaseOrder_purchaseOrderID = c.Int(),
                    })
                .PrimaryKey(t => t.purchaseOrderItemID)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrder_purchaseOrderID)
                .Index(t => t.PurchaseOrder_purchaseOrderID);
            
            DropColumn("dbo.OrderItems", "PurchaseOrder_purchaseOrderID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "PurchaseOrder_purchaseOrderID", c => c.Int());
            DropForeignKey("dbo.PurchaseOrderItems", "PurchaseOrder_purchaseOrderID", "dbo.PurchaseOrders");
            DropIndex("dbo.PurchaseOrderItems", new[] { "PurchaseOrder_purchaseOrderID" });
            DropTable("dbo.PurchaseOrderItems");
            CreateIndex("dbo.OrderItems", "PurchaseOrder_purchaseOrderID");
            AddForeignKey("dbo.OrderItems", "PurchaseOrder_purchaseOrderID", "dbo.PurchaseOrders", "purchaseOrderID");
        }
    }
}
