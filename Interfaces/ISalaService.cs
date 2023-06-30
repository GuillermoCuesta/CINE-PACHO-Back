using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ISalaService
    {
        Task<IActionResult> Mostrar(int funcion);

    }
}
