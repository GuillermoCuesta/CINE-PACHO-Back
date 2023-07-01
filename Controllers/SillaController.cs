using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/sillas")]
    [ApiController]
    public class SillaController : ControllerBase
    {
        private readonly IEntityService<Silla> _entityService;

        public SillaController(IEntityService<Silla> entityService)
        {
            _entityService = entityService;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Crear([FromBody] Silla silla)
        {
            return await _entityService.Crear(silla);
        }

        [HttpGet]
        public async Task<IActionResult> Mostrar()
        {
            return await _entityService.Mostrar();
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Editar([FromBody] Silla silla)
        {
            return await _entityService.Editar(silla);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return await _entityService.Eliminar(id);
        }
    }
}

