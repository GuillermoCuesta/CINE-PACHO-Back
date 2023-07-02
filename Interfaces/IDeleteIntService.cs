using Microsoft.AspNetCore.Mvc;

namespace WebApi.Interfaces
{
    public interface IDeleteIntService
    {
        Task<IActionResult> Eliminar(int id);
    }
}
