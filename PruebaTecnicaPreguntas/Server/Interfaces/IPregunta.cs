using PruebaTecnicaPreguntas.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaPreguntas.Server.Interfaces
{
    public interface IPregunta
    {
       

        public Task<IEnumerable<Preguntas>> ObtenerPreguntas();
        public Task<Preguntas> AgregarPregunta(Preguntas pregunta);
        public Task<Preguntas> BuscarPreguntaPorId(int id);


    }
}
