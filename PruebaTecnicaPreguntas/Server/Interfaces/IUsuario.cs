using PruebaTecnicaPreguntas.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaPreguntas.Server.Interfaces
{
    public interface IUsuario
    {
        public Task<bool> RegistrarUsuario(Usuario usuario);
        public Task<Usuario> LoginUser(Usuario usuario);
    }
}
