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
    public class RespuestasController : ControllerBase
    {
        private IRespuesta Servicio;
        public RespuestasController(IRespuesta servicio)
        {
            Servicio = servicio;
        }

        // GET api/<RespuestasController>/populares/5
        [HttpGet("populares/{IdPregunta}")]
        public async Task<IEnumerable<Respuestas>> ObtenerRespuestasPopulares(int IdPregunta)
        {
            return await Servicio.ObtenerRespuestasPopulares(IdPregunta);
        }

        // GET api/<RespuestasController>/verRespuestas/5
        [HttpGet("verRespuestas/{IdPregunta}")]
        public async Task<IEnumerable<Respuestas>> ObtenerRespuestas(int IdPregunta)
        {
            return await Servicio.ObtenerRespuestas(IdPregunta);
        }

        // GET api/<RespuestasController>/verRespuestas/5
        [HttpGet("Like/{IdRespuesta}")]
        public async Task<int> DarLike(int IdRespuesta)
        {
            await Servicio.Like(IdRespuesta);
            return 1;
        }


        // POST api/<RespuestasController>
        [HttpPost]
        public async Task<Respuestas> Post([FromBody] Respuestas respuesta)
        {
            return await Servicio.AgregarRespuesta(respuesta);
        }


        // GET: api/<RespuestasController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RespuestasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // PUT api/<RespuestasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RespuestasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
