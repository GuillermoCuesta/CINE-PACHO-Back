using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IMultiplexService
    {
        Task<IActionResult> Crear(Multiplex multiplex);
        Task<IActionResult> Mostrar();
        Task<IActionResult> Editar(Multiplex multiplex);
        Task<IActionResult> Eliminar(int id);
    }
}
