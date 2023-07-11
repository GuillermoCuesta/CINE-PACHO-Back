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
    public class MultiplexService : IMultiplexService
    {
        public async Task<IActionResult> Crear(Multiplex multiplex)
        {
            try
            {
                Connection.Instance.Open();
                // Crear el comando para ejecutar el procedimiento almacenado
                SqlCommand command = new SqlCommand("RegistrarMultiplex", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Ubicacion", multiplex.Ubicacion);
                command.Parameters.AddWithValue("@Direccion", multiplex.Direccion);
                command.Parameters.AddWithValue("@ImagenMultiplex", multiplex.ImagenMultiplex);
                await command.ExecuteNonQueryAsync();

                Connection.Instance.Close();

                return new StatusCodeResult(200); // Retornar una respuesta exitosa
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

        public async Task<IActionResult> Mostrar()
        {
            try
            {
                Connection.Instance.Open();
                // Crear la consulta SQL para obtener todos los usuarios
                string query = "SELECT * FROM MULTIPLEX";
                SqlCommand command = new SqlCommand(query, Connection.Instance.Conectar);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<Multiplex> multiplexes = new List<Multiplex>();

                while (reader.Read())
                {
                    // Construir el objeto Usuario con los datos obtenidos de la base de datos
                    Multiplex multiplex = new Multiplex
                    {
                        IdMultiplex = (int)reader["ID_MULTIPLEX"],
                        Ubicacion = (string)reader["UBICACION"],
                        Direccion = (string)reader["DIRECCION"],
                        ImagenMultiplex = (string)reader["IMAGEN_MULTIPLEX"]
                    };

                    multiplexes.Add(multiplex);
                }

                reader.Close(); // Cerrar el DataReader

                Connection.Instance.Close();

                return new JsonResult(multiplexes); // Retornar la lista de multiplexes como respuesta JSON
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

        public async Task<IActionResult> Editar(Multiplex multiplex)
        {
            try
            {
                Connection.Instance.Open();

                // Crear la consulta SQL para actualizar los datos del usuario en la base de datos
                //string query = "UPDATE MULTIPLEX SET UBICACION = @Ubicacion, DIRECCION = @Direccion, IMAGEN_MULTIPLEX = @ImagenMultiplex WHERE ID_MULTIPLEX = @IdMultiplex; ";


                SqlCommand command = new SqlCommand("ActualizarMultiplex", Connection.Instance.Conectar);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdMultiplex", multiplex.IdMultiplex);
                command.Parameters.AddWithValue("@Ubicacion", multiplex.Ubicacion);
                command.Parameters.AddWithValue("@Direccion", multiplex.Direccion);
                command.Parameters.AddWithValue("@ImagenMultiplex", multiplex.ImagenMultiplex);
                int rowsAffected = await command.ExecuteNonQueryAsync();

                Connection.Instance.Close();

                if (rowsAffected > 0)
                {
                    return new OkResult(); // Devolver respuesta 200 OK
                }
                else
                {
                    return new NotFoundResult(); // Devolver respuesta 404 Not Found
                }
            }
            catch (Exception ex)
            {
                // Registra la excepción para obtener más detalles
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

                SqlCommand command = new SqlCommand("EliminarMultiplex", Connection.Instance.Conectar);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdMultiplex", id);
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
