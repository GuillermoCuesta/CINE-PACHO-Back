using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApi.Data_Access;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class SnackService : ISnackService
    {
        public async Task<IActionResult> Crear(Snack snack)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("CrearSnack", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NombreSnack", snack.NombreSnack);
                command.Parameters.AddWithValue("@PrecioSnack", snack.PrecioSnack);
                command.Parameters.AddWithValue("@ImagenSnack", snack.ImagenSnack);
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

        public async Task<IActionResult> Mostrar(int multiplex)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("MostrarSnacks", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdMultiplex", multiplex
                    );
                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<Snack> snacks = new List<Snack>();

                while (reader.Read())
                {
                    Snack snack = new Snack

                    {
                        IdSnack = (int)reader["ID_SNACK"],
                        NombreSnack = (string)reader["NOMBRE_SNACK"],
                        PrecioSnack = (int)reader["PRECIO_SNACK"],
                        ImagenSnack = (string)reader["IMAGEN_SNACK"],
                        CantidadInStock = (int)reader["CANTIDAD_EN_STOCK"]
                    };

                    snacks.Add(snack);
                }

                reader.Close(); // Cerrar el DataReader

                Connection.Instance.Close();

                return new JsonResult(snacks); // Retornar la lista de multiplexes como respuesta JSON
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

        public async Task<IActionResult> Editar(Snack snack)
        {
            try
            {
                Connection.Instance.Open();
                SqlCommand command = new SqlCommand("ActualizarSnack", Connection.Instance.Conectar);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdScnak", snack.IdSnack);
                command.Parameters.AddWithValue("@NombreSnack", snack.NombreSnack);
                command.Parameters.AddWithValue("@PrecioSnack", snack.PrecioSnack);
                command.Parameters.AddWithValue("@ImagenSnack", snack.ImagenSnack);
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
    }
}
