using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApi.Data_Access;
using WebApi.Models;

namespace WebApi.Services
{
    public class ClienteService
    {
        public async Task<int> Validar(CompraCliente cliente)
        {
            try
            {
                Connection.Instance.Open();

                SqlCommand command = new SqlCommand("ValidarExistenciaCliente", Connection.Instance.Conectar);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CedulaCliente", cliente.CedulaCliente);
                command.Parameters.AddWithValue("@NombreCliente", cliente.NombreCliente);
                command.Parameters.AddWithValue("@NumTelefono", cliente.NumTelefonoCliente);

                SqlParameter idClienteParam = new SqlParameter("@ID_CLIENTE", SqlDbType.Int);
                idClienteParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(idClienteParam);

                await command.ExecuteNonQueryAsync();

                int idCliente = (int)command.Parameters["@ID_CLIENTE"].Value;

                Connection.Instance.Close();

                return idCliente;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }
    }
}
