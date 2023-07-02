using Microsoft.AspNetCore.Mvc;

namespace WebApi.Interfaces
{
    public interface IReadEntityService<T>
    {
        Task<IActionResult> Mostrar(T sala);
    }
}
