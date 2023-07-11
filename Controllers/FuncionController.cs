using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/funciones")]
    [ApiController]
    public class FuncionController : ControllerBase
    {
        private readonly IFuncionService _funcionService;

        public FuncionController(IFuncionService funcionService)
        {
            _funcionService = funcionService;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Crear([FromBody] Funcion funcion)
        {
            return await _funcionService.Crear(funcion);
        }

        [HttpGet]
        public async Task<IActionResult> Mostrar(int multiplex)
        {
            return await _funcionService.Mostrar(multiplex);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Editar([FromBody] Funcion funcion)
        {
            return await _funcionService.Editar(funcion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return await _funcionService.Eliminar(id);
        }
    }
}
