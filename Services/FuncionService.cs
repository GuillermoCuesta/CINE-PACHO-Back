using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
using WebApi.Data_Access;
using WebApi.Interfaces;
using WebApi.Models;
using System.Collections.Generic;

namespace WebApi.Services
{
    public class FuncionService : IEntityService<Funcion>
    {
        public async Task<IActionResult> Crear(Funcion funcion)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("RegistrarFuncion", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdMultiplex", funcion.IdMultiplex);
                command.Parameters.AddWithValue("@NumSala", funcion.NumSala);
                command.Parameters.AddWithValue("@IdPelicula", funcion.IdPelicula);
                command.Parameters.AddWithValue("@Estado", funcion.Estado);
                command.Parameters.AddWithValue("@FechaInicio", funcion.FechaInicio);
                command.Parameters.AddWithValue("@FechaFin", funcion.FechaFin);

                await command.ExecuteNonQueryAsync();

                Connection.Instance.Close();

                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> Mostrar()
        {
            try
            {
                Connection.Instance.Open();

                string query = "SELECT * FROM FUNCION";
                SqlCommand command = new SqlCommand(query, Connection.Instance.Conectar);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<Funcion> funciones = new List<Funcion>();

                while (reader.Read())
                {
                    Funcion funcion = new Funcion
                    {
                        IdFuncion = (int)reader["ID_FUNCION"],
                        IdMultiplex = (int)reader["ID_MULTIPLEX"],
                        NumSala = (int)reader["NUM_SALA"],
                        IdPelicula = (int)reader["ID_PELICULA"],
                        Estado = (string)reader["ESTADO"],
                        FechaInicio = (DateTime)reader["FECHA_INICIO"],
                        FechaFin = (DateTime)reader["FECHA_FIN"]
                    };

                    funciones.Add(funcion);
                }

                reader.Close();
                Connection.Instance.Close();

                return new JsonResult(funciones);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> Editar(Funcion funcion)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("ActualizarFuncion", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdFuncion", funcion.IdFuncion);
                command.Parameters.AddWithValue("@IdMultiplex", funcion.IdMultiplex);
                command.Parameters.AddWithValue("@NumSala", funcion.NumSala);
                command.Parameters.AddWithValue("@IdPelicula", funcion.IdPelicula);
                command.Parameters.AddWithValue("@Estado", funcion.Estado);
                command.Parameters.AddWithValue("@FechaInicio", funcion.FechaInicio);
                command.Parameters.AddWithValue("@FechaFin", funcion.FechaFin);

                int rowsAffected = await command.ExecuteNonQueryAsync();

                Connection.Instance.Close();

                if (rowsAffected > 0)
                {
                    return new OkResult();
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                var errorResponse = new ErrorResponse
                {
                    StatusCode = 500,
                    Message = "Se produjo un error en el servidor."
                };

                return new ObjectResult(errorResponse)
                {
                    StatusCode = 500
                };
            }
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("EliminarFuncion", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdFuncion", id);

                int rowsAffected = await command.ExecuteNonQueryAsync();

                Connection.Instance.Close();

                if (rowsAffected > 0)
                {
                    return new StatusCodeResult(200);
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        public class ErrorResponse
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
        }
    }
}
