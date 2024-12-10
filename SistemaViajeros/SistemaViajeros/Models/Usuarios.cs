using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaViajeros.Models
{
    public class Usuarios
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }

    }
}