using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IEntityService<T>
    {
        Task<IActionResult> Crear(T entidad);
        Task<IActionResult> Editar(T entidad);
    }
}
