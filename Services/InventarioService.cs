using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApi.Data_Access;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class InventarioService : IInventarioService
    {
        public async Task<IActionResult> Crear(Inventario inventario)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("RegistrarIventario", Connection.Instance.Conectar);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IdSnack", inventario.IdSnack);
                command.Parameters.AddWithValue("@IdMultiplex", inventario.IdMultiplex);
                command.Parameters.AddWithValue("@CantidadInStock", inventario.CantidadInStock);

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

                SqlCommand command = new SqlCommand("MostrarInventarios", Connection.Instance.Conectar);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdMultiplex", multiplex);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<Inventario> inventarios = new List<Inventario>();

                while (reader.Read())
                {
                    // Construir el objeto Usuario con los datos obtenidos de la base de datos
                    Inventario inventario = new Inventario
                    {
                        IdSnack = (int)reader["ID_SNACK"],
                        NombreSnack = (string)reader["NOMBRE_SNACK"],
                        CantidadInStock = (int)reader["CANTIDAD_EN_STOCK"],
                        PrecioSnack = (int)reader["PRECIO_SNACK"],
                        Ubicacion = (string)reader["UBICACION"],
                        IdMultiplex = multiplex

                    };

                    inventarios.Add(inventario);
                }
                reader.Close(); // Cerrar el DataReader

                Connection.Instance.Close();

                return new JsonResult(inventarios); // Retornar la lista de snacks como respuesta JSON
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

        public async Task<IActionResult> Actualizar(Inventario inventario)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("ActualizarInventario", Connection.Instance.Conectar);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdMultiplex", inventario.IdMultiplex);
                command.Parameters.AddWithValue("@IdSnack", inventario.IdSnack);
                command.Parameters.AddWithValue("@CantidadEnStock", inventario.CantidadInStock);
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

        public async Task<bool> Editar(CompraCliente compracliente)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("DescontarInventario", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var item in compracliente.Snacks)
                {
                    command.Parameters.AddWithValue("@IdCompra", compracliente.IdCompra);
                    command.Parameters.AddWithValue("@IdSnack", item.Item1);
                    command.Parameters.AddWithValue("@IdMultiplex", compracliente.IdMultiplex);
                    command.Parameters.AddWithValue("@CantidadItem", item.Item2);

                    await command.ExecuteNonQueryAsync();
                }

                Connection.Instance.Close();

                return true;
            }
            catch (Exception ex)
            {
                // Registra la excepción para obtener más detalles
                var errorResponse = new ErrorResponse
                {
                    StatusCode = 500,
                    Message = ex.ToString()
                };

                return false;
            }
        }
    }
}
