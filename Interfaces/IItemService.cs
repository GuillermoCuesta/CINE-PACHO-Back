using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IItemService
    {
        Task<IActionResult> Crear(CompraCliente compracliente);
    }
}
