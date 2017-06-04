namespace FBVLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customerID = c.Int(nullable: false, identity: true),
                        customerName = c.String(),
                        address_AddressID = c.Int(),
                    })
                .PrimaryKey(t => t.customerID)
                .ForeignKey("dbo.Addresses", t => t.address_AddressID)
                .Index(t => t.address_AddressID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        doorNumber = c.String(),
                        buildingName = c.String(),
                        streetNumber = c.String(),
                        streetName = c.String(),
                        addressLine2 = c.String(),
                        addressLine3 = c.String(),
                        town = c.String(),
                        region = c.String(),
                        postalCode = c.String(),
                        country = c.String(),
                    })
                .PrimaryKey(t => t.AddressID);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        orderItemID = c.Int(nullable: false, identity: true),
                        shortDescription = c.String(),
                        fullDescription = c.String(),
                        unitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        type = c.Int(),
                        type1 = c.Int(),
                        startDate = c.DateTime(),
                        endDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        PurchaseOrder_purchaseOrderID = c.Int(),
                    })
                .PrimaryKey(t => t.orderItemID)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrder_purchaseOrderID)
                .Index(t => t.PurchaseOrder_purchaseOrderID);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        purchaseOrderID = c.Int(nullable: false, identity: true),
                        timeOrderPlaced = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.purchaseOrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "PurchaseOrder_purchaseOrderID", "dbo.PurchaseOrders");
            DropForeignKey("dbo.Customers", "address_AddressID", "dbo.Addresses");
            DropIndex("dbo.OrderItems", new[] { "PurchaseOrder_purchaseOrderID" });
            DropIndex("dbo.Customers", new[] { "address_AddressID" });
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Addresses");
            DropTable("dbo.Customers");
        }
    }
}
