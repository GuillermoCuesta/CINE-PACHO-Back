using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class SillaService : IEntityService<Silla>
    {
        public async Task<IActionResult> Crear(Silla silla)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Editar(Silla silla)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Mostrar()
        {
            throw new NotImplementedException();
        }
    }
}
