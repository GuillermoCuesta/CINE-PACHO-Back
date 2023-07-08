using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IBoletaService
    {
        Task<bool> Crear(CompraCliente compracliente);
    }
}
