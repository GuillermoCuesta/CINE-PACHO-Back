using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ICompraService
    {
        Task<IActionResult> Crear(CompraCliente compracliente);
        Task<IActionResult> Mostrar();
    }
}
