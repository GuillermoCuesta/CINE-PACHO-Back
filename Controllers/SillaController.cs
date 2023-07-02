using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/sillas")]
    [ApiController]
    public class SillaController : ControllerBase
    {
        private readonly IEntityService<Silla> _entityService;
        private readonly IDeleteEntityService<Silla> _deleteService;
        private readonly IReadEntityService<Silla> _readEntityService;

        public SillaController(IEntityService<Silla> entityService, IDeleteEntityService<Silla> deleteService, IReadEntityService<Silla> readEntityService)
        {
            _entityService = entityService;
            _deleteService = deleteService;
            _readEntityService = readEntityService;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Crear([FromBody] Silla silla)
        {
            return await _entityService.Crear(silla);
        }

        [HttpPost]
        [Route("mostrar")]
        public async Task<IActionResult> Mostrar([FromBody] Silla sala)
        {
            return await _readEntityService.Mostrar(sala);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Editar([FromBody] Silla silla)
        {
            return await _entityService.Editar(silla);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(Silla silla)
        {
            return await _deleteService.Eliminar(silla);
        }

    }
}

