namespace ElectrodomesticosWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class llaveForanea : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Imagens", "DetalleProductoId", "dbo.DetalleProductoes");
            DropIndex("dbo.Imagens", new[] { "DetalleProductoId" });
            AddColumn("dbo.DetalleProductoes", "ImagenId", c => c.Int());
            CreateIndex("dbo.DetalleProductoes", "ImagenId");
            AddForeignKey("dbo.DetalleProductoes", "ImagenId", "dbo.Imagens", "ImagenId");
            DropColumn("dbo.Imagens", "DetalleProductoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Imagens", "DetalleProductoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.DetalleProductoes", "ImagenId", "dbo.Imagens");
            DropIndex("dbo.DetalleProductoes", new[] { "ImagenId" });
            DropColumn("dbo.DetalleProductoes", "ImagenId");
            CreateIndex("dbo.Imagens", "DetalleProductoId");
            AddForeignKey("dbo.Imagens", "DetalleProductoId", "dbo.DetalleProductoes", "Id", cascadeDelete: true);
        }
    }
}
