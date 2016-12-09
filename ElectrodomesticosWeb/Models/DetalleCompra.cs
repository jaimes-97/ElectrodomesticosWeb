using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectrodomesticosWeb.Models
{
    public class DetalleCompra
    {
        public int Id { get; set; }
        [DisplayName("cantidad de productos")]
        [Required(ErrorMessage = "Es requerido ingresar la cantidad del producto")]
        public int Cantidad { get; set; }//cantidad de un producto que añade al carrito
        public float TotalCompra { get; set; }


        public int? CompraId { get; set; }//hace referencia a la foranea de compra

        public virtual Compra Compra { get; set; }

        public int? DetalleProductoId { get; set; }//hace referencia a la foranea de DetalleProducto

        public virtual DetalleProducto DetalleProducto { get; set; }
    }
}