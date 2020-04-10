namespace PF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Despacho : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Despachoes", new[] { "Cliente_clienteId" });
            DropIndex("dbo.Despachoes", new[] { "Producto_ProductoId" });
            DropIndex("dbo.Despachoes", new[] { "tipodeaccion_TipoDeAccionId" });
            RenameColumn(table: "dbo.Clientes", name: "Cliente_clienteId", newName: "Despacho_DespachoId");
            RenameColumn(table: "dbo.Productoes", name: "Producto_ProductoId", newName: "Despacho_DespachoId");
            RenameColumn(table: "dbo.TipoDeAccions", name: "tipodeaccion_TipoDeAccionId", newName: "Despacho_DespachoId");
            CreateIndex("dbo.Clientes", "Despacho_DespachoId");
            CreateIndex("dbo.Productoes", "Despacho_DespachoId");
            CreateIndex("dbo.TipoDeAccions", "Despacho_DespachoId");
            DropColumn("dbo.Despachoes", "Cliente_clienteId");
            DropColumn("dbo.Despachoes", "Producto_ProductoId");
            DropColumn("dbo.Despachoes", "tipodeaccion_TipoDeAccionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Despachoes", "tipodeaccion_TipoDeAccionId", c => c.Int());
            AddColumn("dbo.Despachoes", "Producto_ProductoId", c => c.Int());
            AddColumn("dbo.Despachoes", "Cliente_clienteId", c => c.Int());
            DropIndex("dbo.TipoDeAccions", new[] { "Despacho_DespachoId" });
            DropIndex("dbo.Productoes", new[] { "Despacho_DespachoId" });
            DropIndex("dbo.Clientes", new[] { "Despacho_DespachoId" });
            RenameColumn(table: "dbo.TipoDeAccions", name: "Despacho_DespachoId", newName: "tipodeaccion_TipoDeAccionId");
            RenameColumn(table: "dbo.Productoes", name: "Despacho_DespachoId", newName: "Producto_ProductoId");
            RenameColumn(table: "dbo.Clientes", name: "Despacho_DespachoId", newName: "Cliente_clienteId");
            CreateIndex("dbo.Despachoes", "tipodeaccion_TipoDeAccionId");
            CreateIndex("dbo.Despachoes", "Producto_ProductoId");
            CreateIndex("dbo.Despachoes", "Cliente_clienteId");
        }
    }
}
