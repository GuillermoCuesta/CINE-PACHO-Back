using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/sillas")]
    [ApiController]
    public class SillaController : ControllerBase
    {

        private readonly ISillaService _sillaService;

        public SillaController(ISillaService sillaService)
        {
            _sillaService = sillaService;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Crear([FromBody] Silla silla)
        {
            return await _sillaService.Crear(silla);
        }

        [HttpPost]
        [Route("mostrar")]
        public async Task<IActionResult> Mostrar([FromBody] Silla sala)
        {
            return await _sillaService.Mostrar(sala);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Editar([FromBody] Silla silla)
        {
            return await _sillaService.Editar(silla);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(Silla silla)
        {
            return await _sillaService.Eliminar(silla);
        }

    }
}

