using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaPreguntas.Server.Interfaces;
using PruebaTecnicaPreguntas.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaPreguntas.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuario Servicio;

        public UsuarioController(IUsuario servicio)
        {
            Servicio = servicio;
        }


        //POST: api/Usuario
        [HttpPost]
        public async Task<bool>Post(Usuario usuario)
        {
            return await Servicio.RegistrarUsuario(usuario);
        }


        //POST: api/Usuario/LoginUser
        [HttpPost("LoginUser/")]
        public async Task<Usuario> LoginUser(Usuario usuario)
        {
            return await Servicio.LoginUser(usuario);
        }


    }
}
