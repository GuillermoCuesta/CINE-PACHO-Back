using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ISnackService
    {
        Task<IActionResult> Crear(Snack snack);
        Task<IActionResult> Editar(Snack snack);
        Task<IActionResult> Mostrar(int idMultiplex);
    }
}
