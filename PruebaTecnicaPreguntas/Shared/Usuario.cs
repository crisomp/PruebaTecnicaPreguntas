using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaPreguntas.Shared
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
    }
}
