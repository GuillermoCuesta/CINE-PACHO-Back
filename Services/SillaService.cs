using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
using WebApi.Data_Access;
using WebApi.Interfaces;
using WebApi.Models;
using System.Collections.Generic;
using System.Reflection;

namespace WebApi.Services
{
    public class SillaService : IEntityService<Silla>, IDeleteEntityService<Silla>, IReadEntityService<Silla>
    {
        public async Task<IActionResult> Crear(Silla silla)
        {
            try
            {
                Connection.Instance.Open();
                // Crear el comando para ejecutar el procedimiento almacenado
                SqlCommand command = new SqlCommand("RegistrarSilla", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdMultiplex", silla.IdMultiplex);
                command.Parameters.AddWithValue("@NumSala", silla.NumSala);
                command.Parameters.AddWithValue("@NumSilla", silla.NumSilla);
                command.Parameters.AddWithValue("@TipoSilla", silla.TipoSilla);
                await command.ExecuteNonQueryAsync();

                Connection.Instance.Close();

                return new StatusCodeResult(200); // Retornar una respuesta exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y retornar una respuesta de error
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> Mostrar(Silla sala)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("MostrarSillas", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdMultiplex", sala.IdMultiplex);
                command.Parameters.AddWithValue("@numSala", sala.NumSala);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<Silla> sillas = new List<Silla>();

                while (reader.Read())
                {
                    // Construir el objeto Silla con los datos obtenidos de la base de datos
                    Silla silla = new Silla
                    {
                        IdMultiplex = sala.IdMultiplex,
                        NumSala = sala.NumSala,
                        NumSilla = (string)reader["NUM_SILLA"],
                        TipoSilla = (string)reader["TIPO_SILLA"]
                    };

                    // Utilizar un diccionario para almacenar los datos adicionales
                    Dictionary<string, object> additionalData = new Dictionary<string, object>();
                    additionalData.Add("UBICACION", reader["UBICACION"]);

                    // Utilizar reflexión para asignar los datos adicionales a las propiedades de Silla
                    foreach (var kvp in additionalData)
                    {
                        PropertyInfo property = silla.GetType().GetProperty(kvp.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                        if (property != null && property.CanWrite)
                        {
                            property.SetValue(silla, kvp.Value);
                        }
                    }

                    sillas.Add(silla);
                }

                reader.Close(); // Cerrar el DataReader

                Connection.Instance.Close();

                return new JsonResult(sillas); // Retornar la lista de sillas como respuesta JSON
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y retornar una respuesta de error
                return new StatusCodeResult(500);
            }
        }


        public async Task<IActionResult> Editar(Silla silla)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("ActualizarSilla", Connection.Instance.Conectar);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdMultiplex", silla.IdMultiplex);
                command.Parameters.AddWithValue("@NumSala", silla.NumSala);
                command.Parameters.AddWithValue("@NumSilla", silla.NumSilla);
                command.Parameters.AddWithValue("@TipoSilla", silla.TipoSilla);
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

        // Clase para la respuesta de error personalizada
        public class ErrorResponse
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
        }

        public async Task<IActionResult> Eliminar(Silla silla)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("EliminarSilla", Connection.Instance.Conectar);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdMultiplex", silla.IdMultiplex);
                command.Parameters.AddWithValue("@NumSala", silla.NumSala);
                command.Parameters.AddWithValue("@NumSilla", silla.NumSilla);
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
                // Manejar cualquier excepción y retornar una respuesta de error
                return new StatusCodeResult(500);
            }
        }
    }
}

