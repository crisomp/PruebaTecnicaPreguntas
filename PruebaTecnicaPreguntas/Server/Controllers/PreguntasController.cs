using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaPreguntas.Server.Interfaces;
using PruebaTecnicaPreguntas.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnicaPreguntas.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntasController : ControllerBase
    {
        private IPregunta Servicio;

        public PreguntasController(IPregunta servicio)
        {
            Servicio = servicio;
        }


        // GET: api/<PreguntasController>
        [HttpGet]
        public async Task<IEnumerable<Preguntas>> Get()
        {
            return await Servicio.ObtenerPreguntas();
        }

        // GET api/<PreguntasController>/5
        [HttpGet("{id}")]
        public async Task<Preguntas> Get(int id)
        {
            return await Servicio.BuscarPreguntaPorId(id);
        }


        // POST api/<PreguntasController>
        [HttpPost]
        public async Task<Preguntas> Post([FromBody] Preguntas pregunta)
        {
            return await Servicio.AgregarPregunta(pregunta);
        }


        // PUT api/<PreguntasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PreguntasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
