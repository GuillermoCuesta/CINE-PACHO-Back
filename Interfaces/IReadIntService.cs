using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IReadIntService
    {
        Task<IActionResult> Mostrar(int id);
    }
}
