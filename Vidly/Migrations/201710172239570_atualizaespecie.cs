namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizaespecie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Species", "nome", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Species", "nome", c => c.String());
        }
    }
}
