using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/salas")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly IEntityService<Sala> _entityService;
        private readonly IReadIntService _salaService;
        private readonly IDeleteEntityService<Sala> _deleteService;



        public SalaController(IEntityService<Sala> entityService, SalaService salaService, IDeleteEntityService<Sala> deleteService)
        {
            _entityService = entityService;
            _salaService = salaService;
            _deleteService = deleteService;
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

        [HttpDelete]
        public async Task<IActionResult> Eliminar(Sala sala)
        {
            return await _deleteService.Eliminar(sala);
        }
    }
}
