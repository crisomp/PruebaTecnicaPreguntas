using PruebaTecnicaPreguntas.Server.Interfaces;
using PruebaTecnicaPreguntas.Server.Utils;
using PruebaTecnicaPreguntas.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaPreguntas.Server.Servicios
{
    public class UsuarioServicio : IUsuario
    {
        private SqlConfiguration SqlConfig;

        public UsuarioServicio(SqlConfiguration sqlConfig)
        {
            SqlConfig = sqlConfig;
        }

        private SqlConnection Connection()
        {
            return new SqlConnection(SqlConfig.CadenaConexion);
        }


        public async Task<bool> RegistrarUsuario(Usuario usuario)
        {
            SqlConnection sqlConnection = Connection();

            SqlCommand sqlCommand = null;

            bool isSaved = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "dbo.RegistrarUsuario";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@NombreCompleto", usuario.NombreCompleto);
                sqlCommand.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                sqlCommand.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                sqlCommand.Parameters.AddWithValue("@IdRol", usuario.IdRol);

                await sqlCommand.ExecuteNonQueryAsync();

                isSaved = true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return isSaved;

        }

        public async Task<Usuario> LoginUser(Usuario usuario)
        {
            Usuario usuarioDB = new();

            SqlConnection sqlConnection = Connection();

            SqlCommand sqlCommand = null;

            try
            {
                sqlConnection.Open();
                
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "dbo.LoginUser";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                sqlCommand.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);

                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                if (sqlDataReader.Read())
                {
                    usuarioDB.Id = (int)sqlDataReader["Id"];
                    usuarioDB.IdRol = (int)sqlDataReader["IdRol"];
                    usuarioDB.NombreCompleto = (string)sqlDataReader["NombreCompleto"];
                    usuarioDB.NombreRol = (string)sqlDataReader["NombreRol"];
                    usuarioDB.NombreUsuario = (string)sqlDataReader["NombreUsuario"];
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return usuarioDB;
        }
    }
}
