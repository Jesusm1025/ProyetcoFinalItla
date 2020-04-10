namespace PYFP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstadoProductoId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "EstadoProductoId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "EstadoProductoId");
        }
    }
}
