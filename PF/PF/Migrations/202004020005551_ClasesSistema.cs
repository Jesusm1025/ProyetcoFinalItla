namespace PF.Migrations
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
                        RNC = c.String(),
                        tipo_TipoClienteId = c.Int(),
                    })
                .PrimaryKey(t => t.clienteId)
                .ForeignKey("dbo.TipoClientes", t => t.tipo_TipoClienteId)
                .Index(t => t.tipo_TipoClienteId);
            
            CreateTable(
                "dbo.Direccions",
                c => new
                    {
                        DireccionId = c.Int(nullable: false, identity: true),
                        Provincia = c.String(),
                        Municipio = c.String(),
                        barrio = c.String(),
                        Calle = c.String(),
                        Principal = c.Boolean(nullable: false),
                        Cliente_clienteId = c.Int(),
                    })
                .PrimaryKey(t => t.DireccionId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_clienteId)
                .Index(t => t.Cliente_clienteId);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        EmailId = c.Int(nullable: false, identity: true),
                        Dirrecion = c.String(),
                        Principal = c.Boolean(nullable: false),
                        Cliente_clienteId = c.Int(),
                    })
                .PrimaryKey(t => t.EmailId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_clienteId)
                .Index(t => t.Cliente_clienteId);
            
            CreateTable(
                "dbo.Telefonoes",
                c => new
                    {
                        TelefonoId = c.Int(nullable: false, identity: true),
                        NumeroTelefonico = c.String(),
                        Tipo = c.String(),
                        Principal = c.Boolean(nullable: false),
                        Cliente_clienteId = c.Int(),
                    })
                .PrimaryKey(t => t.TelefonoId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_clienteId)
                .Index(t => t.Cliente_clienteId);
            
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
                "dbo.UdMs",
                c => new
                    {
                        UdmId = c.Int(nullable: false, identity: true),
                        UnidadBase = c.String(),
                        UnidadVenta = c.String(),
                        UnidadCompra = c.String(),
                        Producto_ProductoId = c.Int(),
                    })
                .PrimaryKey(t => t.UdmId)
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
            DropForeignKey("dbo.UdMs", "Producto_ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.EstadoProductoes", "Producto_ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.Despachoes", "Cliente_clienteId", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "tipo_TipoClienteId", "dbo.TipoClientes");
            DropForeignKey("dbo.Telefonoes", "Cliente_clienteId", "dbo.Clientes");
            DropForeignKey("dbo.Emails", "Cliente_clienteId", "dbo.Clientes");
            DropForeignKey("dbo.Direccions", "Cliente_clienteId", "dbo.Clientes");
            DropIndex("dbo.UdMs", new[] { "Producto_ProductoId" });
            DropIndex("dbo.EstadoProductoes", new[] { "Producto_ProductoId" });
            DropIndex("dbo.Despachoes", new[] { "tipodeaccion_TipoDeAccionId" });
            DropIndex("dbo.Despachoes", new[] { "Producto_ProductoId" });
            DropIndex("dbo.Despachoes", new[] { "Cliente_clienteId" });
            DropIndex("dbo.Telefonoes", new[] { "Cliente_clienteId" });
            DropIndex("dbo.Emails", new[] { "Cliente_clienteId" });
            DropIndex("dbo.Direccions", new[] { "Cliente_clienteId" });
            DropIndex("dbo.Clientes", new[] { "tipo_TipoClienteId" });
            DropTable("dbo.TipoDeAccions");
            DropTable("dbo.UdMs");
            DropTable("dbo.EstadoProductoes");
            DropTable("dbo.Productoes");
            DropTable("dbo.Despachoes");
            DropTable("dbo.TipoClientes");
            DropTable("dbo.Telefonoes");
            DropTable("dbo.Emails");
            DropTable("dbo.Direccions");
            DropTable("dbo.Clientes");
        }
    }
}
