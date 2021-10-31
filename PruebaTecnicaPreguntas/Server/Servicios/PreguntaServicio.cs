using PruebaTecnicaPreguntas.Server.Interfaces;
using PruebaTecnicaPreguntas.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


using System.Data;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnicaPreguntas.Server.Utils;

namespace PruebaTecnicaPreguntas.Server.Servicios
{
    public class PreguntaServicio : IPregunta
    {
        private SqlConfiguration Config;

        public PreguntaServicio(SqlConfiguration config)
        {
            Config = config;
        }

        private SqlConnection Connetion()
        {
            return new SqlConnection(Config.CadenaConexion);
        }

        public async Task<Preguntas> AgregarPregunta(Preguntas pregunta)
        {
            Preguntas preguntas = new Preguntas();

            SqlConnection sqlConnection = Connetion();

            SqlCommand sqlCommand = null;

            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "dbo.AgregarPregunta";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Pregunta", pregunta.Pregunta);
                sqlCommand.Parameters.AddWithValue("@IdUsuario", 1);

                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                if (sqlDataReader.Read())
                {
                    Preguntas model = new Preguntas
                    {
                        Id = Convert.ToInt32(sqlDataReader["Id"]),
                        IdEstado = Convert.ToInt32(sqlDataReader["IdEstado"]),
                        IdUsuario = Convert.ToInt32(sqlDataReader["IdUsuario"]),
                        NombreEstado = sqlDataReader["NombreEstado"].ToString(),
                        NombreUsuario =  sqlDataReader["NombreUsuario"].ToString(),
                        Pregunta = sqlDataReader["Pregunta"].ToString(),
                        Likes = Convert.ToInt32(sqlDataReader["Likes"])
                    };
                    pregunta = model;
                }

                return preguntas;
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

        public async Task<Preguntas> BuscarPreguntaPorId(int id)
        {
            Preguntas pregunta = new();

            SqlConnection sqlConnection = Connetion();

            SqlCommand sqlCommand = null;

            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "BuscarPreguntaPorId";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", id);

                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                if (sqlDataReader.Read())
                {
                    pregunta.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    pregunta.IdEstado = Convert.ToInt32(sqlDataReader["IdEstado"]);
                    pregunta.IdUsuario = Convert.ToInt32(sqlDataReader["IdUsuario"]);
                    pregunta.Likes = Convert.ToInt32(sqlDataReader["Likes"]);
                    pregunta.Pregunta = sqlDataReader["Pregunta"].ToString();
                    pregunta.NombreEstado = sqlDataReader["NombreEstado"].ToString();
                    pregunta.NombreUsuario = sqlDataReader["NombreUsuario"].ToString();
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

            return pregunta;
        }


        public async Task<IEnumerable<Preguntas>> ObtenerPreguntas()
        {
            List<Preguntas> lista = new ();
            
            SqlConnection sqlConnection = Connetion();

            SqlCommand comm = null;

            try
            {
                sqlConnection.Open();
                comm = sqlConnection.CreateCommand();
                comm.CommandText = "dbo.ObtenerPreguntas";
                comm.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = await comm.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Preguntas model = new()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Likes = Convert.ToInt32(reader["Likes"]),
                        Pregunta = reader["Pregunta"].ToString(),
                        NombreEstado = reader["NombreEstado"].ToString(),
                        NombreUsuario = reader["NombreUsuario"].ToString()
                    };

                    lista.Add(model);
                }

                
            }
            catch (Exception ex)
            {

                throw new Exception( ex.Message ) ;
            }
            finally
            {
                comm.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return lista;
        }
    }
}
