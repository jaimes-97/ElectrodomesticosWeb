using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectrodomesticosWeb.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [DisplayName("Nombre del producto")]
        [Required(ErrorMessage = "Es requerido ingresar el nombre del producto")]
        public string Nombre { get; set; }

        public virtual ICollection<DetalleProducto> DetalleProductos { get; set; }
        public int? CategoriaId { get; set; }//hace referencia a la foranea de categoria

        public virtual Categoria Categoria { get; set; }
        //Enable-Migrations –EnableAutomaticMigrations  para habilitar las migraciones
    }
}