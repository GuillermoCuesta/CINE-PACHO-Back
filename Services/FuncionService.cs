using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
using WebApi.Data_Access;
using WebApi.Interfaces;
using WebApi.Models;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;

namespace WebApi.Services

    public class FuncionService : IFuncionService
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
                var errorResponse = new ErrorResponse
                {
                    StatusCode = 500,
                    Message = ex.ToString()
                };

                return new ObjectResult(errorResponse)
                {
                    StatusCode = 500
                };
            }
        }

        public async Task<IActionResult> Mostrar(int multiplex)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("MostrarFunciones", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdMultiplex", multiplex);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<Funcion> funciones = new List<Funcion>();

                while (reader.Read())
                {
                    Funcion funcion = new Funcion
                    {         
                        Ubicacion = (string)reader["UBICACION"],
                        IdPelicula = (int)reader["ID_PELICULA"],
                        NombrePelicula = (string)reader["NOMBRE_PELICULA"],
                        ImagenPelicula= (string)reader["IMAGEN_PELICULA"],
                        IdFuncion = (int)reader["ID_FUNCION"],
                        IdMultiplex = multiplex,
                        NumSala = (int)reader["NUM_SALA"],
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
                var errorResponse = new ErrorResponse
                {
                    StatusCode = 500,
                    Message = ex.ToString()
                };

                return new ObjectResult(errorResponse)
                {
                    StatusCode = 500
                };
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
                    Message = ex.ToString()
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
              var errorResponse = new ErrorResponse
                {
                    StatusCode = 500,
                    Message = ex.ToString()
                };

                return new ObjectResult(errorResponse)
                {
                    StatusCode = 500
                };
            }
        }

    }
}
