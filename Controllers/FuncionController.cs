using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/funciones")]
    [ApiController]
    public class FuncionController : ControllerBase
    {
        private readonly IEntityService<Funcion> _entityService;

        public FuncionController(IEntityService<Funcion> entityService)
        {
            _entityService = entityService;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Crear([FromBody] Funcion funcion)
        {
            return await _entityService.Crear(funcion);
        }

        [HttpGet]
        public async Task<IActionResult> Mostrar()
        {
            return await _entityService.Mostrar();
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Editar([FromBody] Funcion funcion)
        {
            return await _entityService.Editar(funcion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return await _entityService.Eliminar(id);
        }
    }
}
