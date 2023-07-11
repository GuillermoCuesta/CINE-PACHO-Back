using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ISalaService
    {
        Task<IActionResult> Crear(Sala sala);
        Task<IActionResult> Mostrar(int funcion);
        Task<IActionResult> Editar(Sala sala);
        Task<IActionResult> Eliminar(Sala sala);
    }
}
