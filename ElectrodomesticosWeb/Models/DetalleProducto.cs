using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectrodomesticosWeb.Models
{
    public class DetalleProducto
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string marca { get; set; }
        public int cantidad { get; set; }// representa la existencia
        [DisplayName("Precio del producto")]
        [Required(ErrorMessage = "Es requerido ingresar el precio del producto")]
        public float precio { get; set; }


        public int? ImagenId { get; set; }
        public virtual Imagen Imagen { get; set; }


        public int? ProductoId { get; set; }//hace referencia a la foranea de producto

        public virtual Producto Producto { get; set; }
    }

}