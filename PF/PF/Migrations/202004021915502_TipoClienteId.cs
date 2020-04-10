namespace PF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoClienteId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "tipo_TipoClienteId", "dbo.TipoClientes");
            DropIndex("dbo.Clientes", new[] { "tipo_TipoClienteId" });
            RenameColumn(table: "dbo.Clientes", name: "tipo_TipoClienteId", newName: "TipoClienteId");
            AlterColumn("dbo.Clientes", "TipoClienteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clientes", "TipoClienteId");
            AddForeignKey("dbo.Clientes", "TipoClienteId", "dbo.TipoClientes", "TipoClienteId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "TipoClienteId", "dbo.TipoClientes");
            DropIndex("dbo.Clientes", new[] { "TipoClienteId" });
            AlterColumn("dbo.Clientes", "TipoClienteId", c => c.Int());
            RenameColumn(table: "dbo.Clientes", name: "TipoClienteId", newName: "tipo_TipoClienteId");
            CreateIndex("dbo.Clientes", "tipo_TipoClienteId");
            AddForeignKey("dbo.Clientes", "tipo_TipoClienteId", "dbo.TipoClientes", "TipoClienteId");
        }
    }
}
