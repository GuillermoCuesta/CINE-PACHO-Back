using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ISillaService
    {
        Task<IActionResult> Crear(Silla silla);
        Task<IActionResult> Mostrar(Silla sala);
        Task<IActionResult> Editar(Silla silla);
        Task<IActionResult> Eliminar(Silla silla);
    }
}
