using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaPreguntas.Shared
{
    public class Respuestas
    {
        public int Id { get; set; }
        public int IdPregunta { get; set; }

        [Required(ErrorMessage ="Requerido")]
        [MaxLength(100, ErrorMessage ="Maximo 100 Caracteres")]
        public string Respuesta { get; set; }
        public int Likes { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }

    }
}
