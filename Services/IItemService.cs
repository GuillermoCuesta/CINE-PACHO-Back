using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IItemService
    {
        Task<IActionResult> Crear(CompraCliente compracliente);
    }
}
