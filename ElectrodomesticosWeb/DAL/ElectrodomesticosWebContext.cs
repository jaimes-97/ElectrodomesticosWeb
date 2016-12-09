using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectrodomesticosWeb.Models;
using System.Data.Entity;

namespace ElectrodomesticosWeb.DAL
{
    public class ElectrodomesticosWebContext : DbContext
    {

        public DbSet<Producto> Productos { get; set; }//para cada nuevo modelo se hace esto
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<DetalleProducto> DetalleProductos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}