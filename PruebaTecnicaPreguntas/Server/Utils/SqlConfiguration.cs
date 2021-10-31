using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaPreguntas.Server.Utils
{
    public class SqlConfiguration
    {
        private string cadenaConexion;
        public string CadenaConexion { get => cadenaConexion; }
        public SqlConfiguration(string Conexion)
        {
            cadenaConexion = Conexion;
        }
    }
}
