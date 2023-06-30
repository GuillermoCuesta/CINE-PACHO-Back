using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IUsuarioService
    {
        Task<IActionResult> IniciarSession(Usuario credenciales);
    }
}
