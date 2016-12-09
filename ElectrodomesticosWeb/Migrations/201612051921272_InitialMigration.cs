namespace ElectrodomesticosWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        CategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.DetalleProductoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        marca = c.String(),
                        cantidad = c.Int(nullable: false),
                        precio = c.Single(nullable: false),
                        ProductoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productoes", t => t.ProductoId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Imagens",
                c => new
                    {
                        ImagenId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        DetalleProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImagenId)
                .ForeignKey("dbo.DetalleProductoes", t => t.DetalleProductoId, cascadeDelete: true)
                .Index(t => t.DetalleProductoId);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCliente = c.String(nullable: false),
                        NumTarjeta = c.String(nullable: false),
                        Direccion = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetalleCompras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        TotalCompra = c.Single(nullable: false),
                        CompraId = c.Int(),
                        DetalleProductoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compras", t => t.CompraId)
                .ForeignKey("dbo.DetalleProductoes", t => t.DetalleProductoId)
                .Index(t => t.CompraId)
                .Index(t => t.DetalleProductoId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleCompras", "DetalleProductoId", "dbo.DetalleProductoes");
            DropForeignKey("dbo.DetalleCompras", "CompraId", "dbo.Compras");
            DropForeignKey("dbo.DetalleProductoes", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.Imagens", "DetalleProductoId", "dbo.DetalleProductoes");
            DropForeignKey("dbo.Productoes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.DetalleCompras", new[] { "DetalleProductoId" });
            DropIndex("dbo.DetalleCompras", new[] { "CompraId" });
            DropIndex("dbo.Imagens", new[] { "DetalleProductoId" });
            DropIndex("dbo.DetalleProductoes", new[] { "ProductoId" });
            DropIndex("dbo.Productoes", new[] { "CategoriaId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.DetalleCompras");
            DropTable("dbo.Compras");
            DropTable("dbo.Imagens");
            DropTable("dbo.DetalleProductoes");
            DropTable("dbo.Productoes");
            DropTable("dbo.Categorias");
        }
    }
}
