namespace PYF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClasesSistema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        clienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        TipoClienteId = c.Int(nullable: false),
                        RNC = c.String(),
                        Telefono = c.String(),
                        Direccion = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.clienteId)
                .ForeignKey("dbo.TipoClientes", t => t.TipoClienteId, cascadeDelete: true)
                .Index(t => t.TipoClienteId);
            
            CreateTable(
                "dbo.TipoClientes",
                c => new
                    {
                        TipoClienteId = c.Int(nullable: false, identity: true),
                        NombreTipo = c.String(),
                    })
                .PrimaryKey(t => t.TipoClienteId);
            
            CreateTable(
                "dbo.Despachoes",
                c => new
                    {
                        DespachoId = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        Cliente_clienteId = c.Int(),
                        Producto_ProductoId = c.Int(),
                        tipodeaccion_TipoDeAccionId = c.Int(),
                    })
                .PrimaryKey(t => t.DespachoId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_clienteId)
                .ForeignKey("dbo.Productoes", t => t.Producto_ProductoId)
                .ForeignKey("dbo.TipoDeAccions", t => t.tipodeaccion_TipoDeAccionId)
                .Index(t => t.Cliente_clienteId)
                .Index(t => t.Producto_ProductoId)
                .Index(t => t.tipodeaccion_TipoDeAccionId);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        udm = c.String(),
                        Costo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Existencia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoId);
            
            CreateTable(
                "dbo.EstadoProductoes",
                c => new
                    {
                        EstadoProductoId = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                        Producto_ProductoId = c.Int(),
                    })
                .PrimaryKey(t => t.EstadoProductoId)
                .ForeignKey("dbo.Productoes", t => t.Producto_ProductoId)
                .Index(t => t.Producto_ProductoId);
            
            CreateTable(
                "dbo.TipoDeAccions",
                c => new
                    {
                        TipoDeAccionId = c.Int(nullable: false, identity: true),
                        Accion = c.String(),
                    })
                .PrimaryKey(t => t.TipoDeAccionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Despachoes", "tipodeaccion_TipoDeAccionId", "dbo.TipoDeAccions");
            DropForeignKey("dbo.Despachoes", "Producto_ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.EstadoProductoes", "Producto_ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.Despachoes", "Cliente_clienteId", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "TipoClienteId", "dbo.TipoClientes");
            DropIndex("dbo.EstadoProductoes", new[] { "Producto_ProductoId" });
            DropIndex("dbo.Despachoes", new[] { "tipodeaccion_TipoDeAccionId" });
            DropIndex("dbo.Despachoes", new[] { "Producto_ProductoId" });
            DropIndex("dbo.Despachoes", new[] { "Cliente_clienteId" });
            DropIndex("dbo.Clientes", new[] { "TipoClienteId" });
            DropTable("dbo.TipoDeAccions");
            DropTable("dbo.EstadoProductoes");
            DropTable("dbo.Productoes");
            DropTable("dbo.Despachoes");
            DropTable("dbo.TipoClientes");
            DropTable("dbo.Clientes");
        }
    }
}
