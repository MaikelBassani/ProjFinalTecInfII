namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chavepets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "raca", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Pets", "cor", c => c.String());
            AddColumn("dbo.Pets", "EspecieId", c => c.Int(nullable: false));
            AddColumn("dbo.Pets", "ClienteId", c => c.Int(nullable: false));
            AlterColumn("dbo.Pets", "nome", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Pets", "ClienteId");
            CreateIndex("dbo.Pets", "EspecieId");
            AddForeignKey("dbo.Pets", "ClienteId", "dbo.Customers", "id", cascadeDelete: true);
            AddForeignKey("dbo.Pets", "EspecieId", "dbo.Species", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "EspecieId", "dbo.Species");
            DropForeignKey("dbo.Pets", "ClienteId", "dbo.Customers");
            DropIndex("dbo.Pets", new[] { "EspecieId" });
            DropIndex("dbo.Pets", new[] { "ClienteId" });
            AlterColumn("dbo.Pets", "nome", c => c.String());
            DropColumn("dbo.Pets", "ClienteId");
            DropColumn("dbo.Pets", "EspecieId");
            DropColumn("dbo.Pets", "cor");
            DropColumn("dbo.Pets", "raca");
        }
    }
}
