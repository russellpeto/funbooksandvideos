namespace FBVLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration007 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShippingSlips",
                c => new
                    {
                        shippingSlipID = c.Int(nullable: false, identity: true),
                        shippingName = c.String(),
                        purchaseOrderID = c.Int(nullable: false),
                        shippingAddress_AddressID = c.Int(),
                    })
                .PrimaryKey(t => t.shippingSlipID)
                .ForeignKey("dbo.Addresses", t => t.shippingAddress_AddressID)
                .Index(t => t.shippingAddress_AddressID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShippingSlips", "shippingAddress_AddressID", "dbo.Addresses");
            DropIndex("dbo.ShippingSlips", new[] { "shippingAddress_AddressID" });
            DropTable("dbo.ShippingSlips");
        }
    }
}
