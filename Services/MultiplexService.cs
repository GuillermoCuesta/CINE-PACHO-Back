using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
using WebApi.Data_Access;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class MultiplexService:IMultiplexService
    {
        public async Task<IActionResult> Crear(Multiplex multiplex)
        {
            try
            {
                Connection.abrir();
                // Crear el comando para ejecutar el procedimiento almacenado
                SqlCommand command = new SqlCommand("RegistrarMultiplex", Connection.conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Ubicacion", multiplex.Ubicacion);
                command.Parameters.AddWithValue("@Direccion", multiplex.Direccion);
                command.Parameters.AddWithValue("@ImagenMultiplex", multiplex.ImagenMultiplex);
                await command.ExecuteNonQueryAsync();

                Connection.cerrar();

                return new StatusCodeResult(200); // Retornar una respuesta exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y retornar una respuesta de error
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> Mostrar()
        {
            try
            {
                Connection.abrir();
                // Crear la consulta SQL para obtener todos los usuarios
                string query = "SELECT * FROM MULTIPLEX";
                SqlCommand command = new SqlCommand(query, Connection.conectar);
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

                Connection.cerrar();

                return new JsonResult(multiplexes); // Retornar la lista de multiplexes como respuesta JSON
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y retornar una respuesta de error
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> Editar(Multiplex multiplex)
        {
            try
            {
                Connection.abrir();
                SqlCommand command = new SqlCommand("ActualizarMultiplex", Connection.conectar);
                command.Parameters.AddWithValue("@IdMultiplex", multiplex.IdMultiplex);
                command.Parameters.AddWithValue("@Ubicacion", multiplex.Ubicacion);
                command.Parameters.AddWithValue("@Direccion", multiplex.Direccion);
                command.Parameters.AddWithValue("@ImagenMultiplex", multiplex.ImagenMultiplex);
                int rowsAffected = await command.ExecuteNonQueryAsync();

                Connection.cerrar();

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

        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                Connection.abrir();

                SqlCommand command = new SqlCommand("EliminarMultiplex", Connection.conectar);
                command.Parameters.AddWithValue("@IdMultiplex", id);
                int rowsAffected = await command.ExecuteNonQueryAsync();

                Connection.cerrar();

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
