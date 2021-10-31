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
    public class RespuestaServicio : IRespuesta
    {
        private SqlConfiguration Config;

        public RespuestaServicio(SqlConfiguration config)
        {
            Config = config;
        }

        private SqlConnection Connetion()
        {
            return new SqlConnection(Config.CadenaConexion);
        }


        public async Task Like(int idRespuesta)
        {
            SqlConnection sqlConnection = Connetion();

            SqlCommand sqlCommand = null;


            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "dbo.DarLike";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@IdRespuesta", idRespuesta);

                await sqlCommand.ExecuteNonQueryAsync();

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
        }

        public async Task<Respuestas> AgregarRespuesta(Respuestas respuesta)
        {
            Respuestas respuestas = new ();

            SqlConnection sqlConnection = Connetion();

            SqlCommand sqlCommand = null;

            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "dbo.Responder";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Respuesta", respuesta.Respuesta);
                sqlCommand.Parameters.AddWithValue("@IdUsuario", 1);
                sqlCommand.Parameters.AddWithValue("@IdPregunta", respuesta.IdPregunta);

                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                if (sqlDataReader.Read())
                {
                    Respuestas model = new Respuestas
                    {
                        Id = Convert.ToInt32(sqlDataReader["Id"]),
                        IdUsuario = Convert.ToInt32(sqlDataReader["IdUsuario"]),
                        IdPregunta = Convert.ToInt32(sqlDataReader["IdPregunta"]),
                        NombreUsuario = sqlDataReader["NombreUsuario"].ToString(),
                        Respuesta = sqlDataReader["Pregunta"].ToString(),
                        Likes = Convert.ToInt32(sqlDataReader["Likes"])
                    };
                    respuestas = model;
                }

                return respuestas;
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
        }


        public async Task<IEnumerable<Respuestas>> ObtenerRespuestasPopulares(int idPregunta)
        {
            List<Respuestas> lista = new();

            SqlConnection sqlConnection = Connetion();

            SqlCommand sqlCommand = null;

            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "dbo.ObtenerRespuestasPopulares";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@IdPregunta", idPregunta);


                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                while (sqlDataReader.Read())
                {
                    Respuestas respuesta = new Respuestas
                    {
                        Id = Convert.ToInt32(sqlDataReader["Id"]),
                        IdUsuario = Convert.ToInt32(sqlDataReader["IdUsuario"]),
                        Likes = Convert.ToInt32(sqlDataReader["Likes"]),
                        IdPregunta = Convert.ToInt32(sqlDataReader["IdPregunta"]),
                        NombreUsuario = sqlDataReader["NombreUsuario"].ToString(),
                        Respuesta = sqlDataReader["Respuesta"].ToString()
                    };

                    lista.Add(respuesta);
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

            return lista;
        }


        public async Task<IEnumerable<Respuestas>> ObtenerRespuestas(int idPregunta)
        {
            List<Respuestas> lista = new();

            SqlConnection sqlConnection = Connetion();

            SqlCommand sqlCommand = null;

            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "dbo.ObtenerRespuestas";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@IdPregunta", idPregunta);


                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                while (sqlDataReader.Read())
                {
                    Respuestas respuesta = new Respuestas
                    {
                        Id = Convert.ToInt32(sqlDataReader["Id"]),
                        IdUsuario = Convert.ToInt32(sqlDataReader["IdUsuario"]),
                        Likes = Convert.ToInt32(sqlDataReader["Likes"]),
                        IdPregunta = Convert.ToInt32(sqlDataReader["IdPregunta"]),
                        NombreUsuario = sqlDataReader["NombreUsuario"].ToString(),
                        Respuesta = sqlDataReader["Respuesta"].ToString()
                    };

                    lista.Add(respuesta);
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

            return lista;
        }

    }
}
