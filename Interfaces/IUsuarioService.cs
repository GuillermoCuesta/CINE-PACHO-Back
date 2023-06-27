using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IUsuarioService
    {
        Task<IActionResult> Crear(Usuario usuario);
        Task<IActionResult> IniciarSession(Usuario credenciales);
        Task<IActionResult> Mostrar();
        Task<IActionResult> Editar(Usuario usuario);
        Task<IActionResult> Eliminar(int id);
    }
}
