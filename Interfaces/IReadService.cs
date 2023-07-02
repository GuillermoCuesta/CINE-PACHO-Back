using Microsoft.AspNetCore.Mvc;

namespace WebApi.Interfaces
{
    public interface IReadService
    {
        Task<IActionResult> Mostrar();
    }
}
