using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApi.Data_Access;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class SalaService : IEntityService<Sala>, IReadIntService, IDeleteEntityService<Sala>
    {
        public async Task<IActionResult> Crear(Sala sala)
        {
            try
            {
                Connection.Instance.Open();
                // Crear el comando para ejecutar el procedimiento almacenado
                SqlCommand command = new SqlCommand("RegistrarSala", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdMultiplex", sala.IdMultiplex);
                command.Parameters.AddWithValue("@NumSala", sala.NumSala);
                command.Parameters.AddWithValue("@NumSillasGeneral", sala.NumSillasGeneral);
                command.Parameters.AddWithValue("@NumSillasPreferencial", sala.NumSillasPreferencial);
                await command.ExecuteNonQueryAsync();

                Connection.Instance.Close();

                return new StatusCodeResult(200); // Retornar una respuesta exitosa
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> Mostrar(int funcion)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("MostrarSalas", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdFuncion", funcion);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<Sala> salas = new List<Sala>();

                while (reader.Read())
                {
                    // Construir el objeto Sala con los datos obtenidos de la base de datos
                    Sala sala = new Sala
                    {
                        IdMultiplex = (int)reader["ID_MULTIPLEX"],
                        NumSala = (int)reader["NUM_SALA"],
                        NumSillasGeneral = (int)reader["NUM_SILLAS_GENERAL"],
                        NumSillasPreferencial = (int)reader["NUM_SILLAS_PREFERENCIAL"]
                    };

                    salas.Add(sala);
                }

                reader.Close(); // Cerrar el DataReader

                Connection.Instance.Close();

                return new JsonResult(salas); // Retornar la lista de salas como respuesta JSON
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> Editar(Sala sala)
        {
            try
            {
                Connection.Instance.Open();

                // Crear la consulta SQL para actualizar los datos de la sala en la base de datos
                SqlCommand command = new SqlCommand("ActualizarSala", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdMultiplex", sala.IdMultiplex);
                command.Parameters.AddWithValue("@NumSala", sala.NumSala);
                command.Parameters.AddWithValue("@NumSillasGeneral", sala.NumSillasGeneral);
                command.Parameters.AddWithValue("@NumSillasPreferencial", sala.NumSillasPreferencial);
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
                    Message = "Se produjo un error en el servidor."
                };

                return new ObjectResult(errorResponse)
                {
                    StatusCode = 500
                };
            }
        }

        public class ErrorResponse
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
        }

        public async Task<IActionResult> Eliminar(Sala sala)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("EliminarSala", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdMultiplex", sala.IdMultiplex);
                command.Parameters.AddWithValue("@NumSala", sala.NumSala);

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
    }
}
