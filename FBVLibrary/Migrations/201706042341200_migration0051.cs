namespace FBVLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration0051 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipEntries",
                c => new
                    {
                        MembershipEntryID = c.Int(nullable: false, identity: true),
                        customerID = c.Int(nullable: false),
                        purchaseOrderItemID = c.Int(nullable: false),
                        expiryDate = c.DateTime(nullable: false),
                        bookClubMembership = c.Boolean(nullable: false),
                        videoClubMembership = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MembershipEntryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MembershipEntries");
        }
    }
}
