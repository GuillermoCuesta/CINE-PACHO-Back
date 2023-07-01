using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/salas")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly IEntityService<Sala> _entityService;
        private readonly ISalaService _salaService;


        public SalaController(IEntityService<Sala> entityService, ISalaService salaService)
        {
            _entityService = entityService;
            _salaService = salaService;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Crear([FromBody] Sala sala)
        {
            return await _entityService.Crear(sala);
        }

        [HttpGet]
        public async Task<IActionResult> Mostrar(int funcion)
        {
            return await _salaService.Mostrar(funcion);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Editar([FromBody] Sala sala)
        {
            return await _entityService.Editar(sala);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return await _entityService.Eliminar(id);
        }
    }
}
