using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IInventarioService
    {
        Task<IActionResult> Crear(Inventario inventario);
        Task<IActionResult> Mostrar(int multiplex);
        Task<bool> Editar(CompraCliente compracliente);
        Task<IActionResult> Actualizar(Inventario inventario);
    }
}
