using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IFuncionService
    {
        Task<IActionResult> Crear(Funcion funcion);
        Task<IActionResult> Mostrar(int multiplex);
        Task<IActionResult> Editar(Funcion funcion);
        Task<IActionResult> Eliminar(int id);
    }
}
