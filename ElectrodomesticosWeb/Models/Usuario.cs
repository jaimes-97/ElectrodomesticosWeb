using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectrodomesticosWeb.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [DisplayName("Nombre de usuario")]
        [Required(ErrorMessage = "Es requerido ingresar el nombre de usuario")]
        public string NombreUsuario { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Es requerido ingresar elpassword")]
        public string Password { get; set; }
    }
}