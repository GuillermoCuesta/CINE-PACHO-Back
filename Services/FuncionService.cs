using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class FuncionService : IEntityService<Funcion>
    {
        public async Task<IActionResult> Crear(Funcion funcion)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Editar(Funcion funcion)
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
