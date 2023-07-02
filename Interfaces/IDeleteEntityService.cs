using Microsoft.AspNetCore.Mvc;

namespace WebApi.Interfaces
{
    public interface IDeleteEntityService<T>
    {
        Task<IActionResult> Eliminar(T entidad);

    }
}
