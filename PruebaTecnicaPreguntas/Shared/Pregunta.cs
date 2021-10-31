using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaPreguntas.Shared
{
    public class Preguntas
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Requerido")]
        [MaxLength(75,ErrorMessage ="Maximo 75 letras")]
        public string Pregunta { get; set; }
        public int Likes { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuario { get; set; }
        public string NombreEstado { get; set; }
        public string NombreUsuario { get; set; }

    }
}
