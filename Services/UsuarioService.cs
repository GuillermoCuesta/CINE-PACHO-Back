
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApi.Data_Access;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class UsuarioService : IUsuarioService
    {

        public async Task<IActionResult> Crear(Usuario usuario)
        {
            try
            {
                Connection.Instance.Open();
                // Crear el comando para ejecutar el procedimiento almacenado
                SqlCommand command = new SqlCommand("RegistrarUsuario", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CodEmpleado", usuario.CodEmpleado);
                //command.Parameters.AddWithValue("@ImagenUsuario", usuario.ImagenUsuario);
                command.Parameters.AddWithValue("@CorreoUsuario", usuario.CorreoUsuario);
                command.Parameters.AddWithValue("@ContrasenaUsuario", usuario.ContrasenaUsuario);
                var result = await command.ExecuteNonQueryAsync();

                Connection.Instance.Close();
                //return new StatusCodeResult(200) { Value = result }; // Retornar una respuesta exitosa junto con la variable result

                return new OkObjectResult(result);
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


        public async Task<IActionResult> IniciarSession([FromBody] Usuario credenciales)
        {
            try
            {
                Connection.Instance.Open();
                // Crear el comando para ejecutar el procedimiento almacenado
                SqlCommand command = new SqlCommand("IniciarSesion", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CorreoUsuario", credenciales.CorreoUsuario);
                command.Parameters.AddWithValue("@ContrasenaUsuario", credenciales.ContrasenaUsuario);

                // Agregar un parámetro de salida para capturar el resultado de inicio de sesión
                SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Int);
                resultadoParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(resultadoParam);

                await command.ExecuteNonQueryAsync();

                Connection.Instance.Close();

               
                int resultadoInicioSession = (int)resultadoParam.Value;


                if (resultadoInicioSession == 1)
                {
                    // Inicio de sesión exitoso
                    return new StatusCodeResult(200);
                }
                else if (resultadoInicioSession == 2)
                {
                    var errorResponse = new ErrorResponse
                    {
                        StatusCode = 500,
                        Message = "Credenciales invalidas"
                    };

                    return new ObjectResult(errorResponse)
                    {
                        StatusCode = 500
                    };
                }
                else
                {
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
                SqlCommand command = new SqlCommand("MostrarUsuarios", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<Usuario> usuarios = new List<Usuario>();

                while (reader.Read())
                {
                    // Construir el objeto Usuario con los datos obtenidos de la base de datos
                    Usuario usuario = new Usuario
                    {
                        IdUsuario = (int)reader["ID_USUARIO"],
                        CodEmpleado = (int)reader["COD_EMPLEADO"],
                        CorreoUsuario = (string)reader["CORREO_USUARIO"],
                        ContrasenaUsuario = (string)reader["CONTRASENA_USUARIO"]
                    };

                    usuarios.Add(usuario);
                }

                reader.Close(); // Cerrar el DataReader

                Connection.Instance.Close();

                return new JsonResult(usuarios); // Retornar la lista de usuarios como respuesta JSON
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



        public async Task<IActionResult> Editar(Usuario usuario)

        {
            try
            {
                Connection.Instance.Open();

                // Crear la consulta SQL para actualizar los datos del usuario en la base de datos
                // string query = "UPDATE Usuarios SET CodEmpleado = @CodEmpleado, ImagenUsuario = @ImagenUsuario, CorreoUsuario = @CorreoUsuario, ContrasenaUsuario = @ContrasenaUsuario WHERE IdUsuario = @IdUsuario";

                SqlCommand command = new SqlCommand("ActualizarUsuario", Connection.Instance.Conectar);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CodEmpleado", usuario.CodEmpleado);
                command.Parameters.AddWithValue("@ImagenUsuario", usuario.ImagenUsuario);
                command.Parameters.AddWithValue("@CorreoUsuario", usuario.CorreoUsuario);
                command.Parameters.AddWithValue("@ContrasenaUsuario", usuario.ContrasenaUsuario);
                command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
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

        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("EliminarUsuario", Connection.Instance.Conectar);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdUsuario", id);
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
