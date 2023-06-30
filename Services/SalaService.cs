using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class SalaService : IEntityService<Sala>, ISalaService
    {
        public async Task<IActionResult> Crear(Sala sala)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Editar(Sala sala)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<IActionResult> Mostrar(int funcion)
        {
            throw new NotImplementedException();
        }
        public async Task<IActionResult> Mostrar()
        {
            // Implementación vacía o lanzar una excepción
            return null; // O cualquier otro valor que sea apropiado en tu caso
        }
    }
}
