namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "cpf", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Customers", "endereco", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "bairro", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "num_casa", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "nome", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "nome", c => c.String());
            DropColumn("dbo.Customers", "num_casa");
            DropColumn("dbo.Customers", "bairro");
            DropColumn("dbo.Customers", "endereco");
            DropColumn("dbo.Customers", "cpf");
        }
    }
}
