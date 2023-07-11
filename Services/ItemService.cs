using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NLog.Fluent;
using WebApi.Data_Access;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class ItemService : IItemService
    {

        public async Task<IActionResult> Crear(CompraCliente compracliente)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("RegistrarItems", Connection.Instance.Conectar);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                foreach (var item in compracliente.Snacks)
                {
                    command.Parameters.AddWithValue("@IdCompra", compracliente.IdCompra);
                    command.Parameters.AddWithValue("@IdSnack", item.Item1);
                    command.Parameters.AddWithValue("@CantidadItem", item.Item2);

                    await command.ExecuteNonQueryAsync();
                }
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
    }
}
