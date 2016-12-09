using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectrodomesticosWeb.Models
{
    public class Imagen
    {

        public int ImagenId { get; set; }
        [StringLength(255)]
        public string ImageName { get; set; }
        public FileType FileType { get; set; }
       
    }
}