namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationstoCustomerName : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipTypeId" });
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                {
                    Id = c.Byte(nullable: false),
                    SignUpFee = c.Short(nullable: false),
                    DurationInMonths = c.Byte(nullable: false),
                    DisountRate = c.Byte(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Customers", "MemberShipTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Customers", "MemberShipTypeId");
            AddForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
