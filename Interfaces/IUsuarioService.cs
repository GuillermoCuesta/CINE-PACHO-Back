using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IUsuarioService
    {
        Task<IActionResult> IniciarSession(Usuario credenciales);
        Task<IActionResult> Mostrar();
        Task<IActionResult> Crear(Usuario usuario);
        Task<IActionResult> Editar(Usuario usuario);
        Task<IActionResult> Eliminar(int id);

    }
}
