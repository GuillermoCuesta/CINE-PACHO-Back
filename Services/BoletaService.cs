using Microsoft.Data.SqlClient;
using System.Data;
using WebApi.Data_Access;
using WebApi.Interfaces;
using WebApi.Models;


namespace WebApi.Services
{
    public class BoletaService : IBoletaService
    {
        public async Task<bool> Crear(CompraCliente compracliente)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("RegistrarBoletas", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var item in compracliente.Sillas)
                {
                    command.Parameters.AddWithValue("@IdCompra", compracliente.IdCompra);
                    command.Parameters.AddWithValue("@IdMultiplex", compracliente.IdMultiplex);
                    command.Parameters.AddWithValue("@NumSala", item.NumSala);
                    command.Parameters.AddWithValue("@NumSilla", item.NumSilla);

                    await command.ExecuteNonQueryAsync();
                }
                Connection.Instance.Close();

                return true;
            }
            catch (Exception ex)
            {
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

