using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApi.Data_Access;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class CompraService : ICompraService
    {

        private readonly IInventarioService _inventarioService;
        private readonly IBoletaService _boletaService;

        public CompraService(IInventarioService inventarioService, IBoletaService boletaService)
        {
            _inventarioService = inventarioService;
            _boletaService = boletaService;
        }

        public async Task<IActionResult> Crear(CompraCliente compracliente)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("RegistrarCompra", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CedulaCliente", compracliente.CedulaCliente);
                command.Parameters.AddWithValue("@NombreCliente", compracliente.NombreCliente);
                command.Parameters.AddWithValue("@NumTelefono", compracliente.NumTelefonoCliente);
                command.Parameters.AddWithValue("@FechaCompra", DateTime.Now);
                command.Parameters.AddWithValue("@TotalCompra", compracliente.TotalCompra);

                await command.ExecuteNonQueryAsync();

                // Consulta para obtener el ID_COMPRA generado
                SqlCommand getIdCommand = new SqlCommand("SELECT TOP 1 ID_COMPRA FROM COMPRA ORDER BY ID_COMPRA DESC;", Connection.Instance.Conectar);
                int idCompra = Convert.ToInt32(getIdCommand.ExecuteScalar());

                compracliente.IdCompra = idCompra;

                Connection.Instance.Close();

                if ((await _inventarioService.Editar(compracliente)).Equals(true))
                {
                    if ((await _boletaService.Crear(compracliente)).Equals(true))
                    {
                        return new StatusCodeResult(200);
                    }
                    else
                    {
                        return new StatusCodeResult(500);
                    }
                }
                else
                {
                    return new StatusCodeResult(500);
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

                SqlCommand command = new SqlCommand("SELECT * FROM COMPRA;", Connection.Instance.Conectar);
                command.CommandType = CommandType.Text;
                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<Compra> compras = new List<Compra>();

                while (reader.Read())
                {
                    Compra compra = new Compra
                    {
                        IdCompra = (int)reader["ID_COMPRA"],
                        IdCliente = (int)reader["ID_CLIENTE"],
                        FechaCompra = (DateTime)reader["FECHA_COMPRA"],
                        TotalCompra = (decimal)reader["TOTAL_COMPRA"]
                    };
                    compras.Add(compra);
                }

                reader.Close();

                Connection.Instance.Close();

                return new JsonResult(compras); // Retornar la lista de multiplexes como respuesta JSON
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
