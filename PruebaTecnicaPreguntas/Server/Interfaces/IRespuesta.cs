using PruebaTecnicaPreguntas.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaPreguntas.Server.Interfaces
{
    public interface IRespuesta
    {
        public Task<IEnumerable<Respuestas>> ObtenerRespuestasPopulares(int idPregunta);
        public Task<IEnumerable<Respuestas>> ObtenerRespuestas(int idPregunta);
        public Task<Respuestas> AgregarRespuesta(Respuestas respuesta);
        public Task Like(int idRespuesta);
    }
}
