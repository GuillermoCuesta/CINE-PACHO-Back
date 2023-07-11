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
        private readonly ISalaService _salaService;

        public SalaController(ISalaService salaService)
        {
            _salaService = salaService;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Crear([FromBody] Sala sala)
        {
            return await _salaService.Crear(sala);
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
            return await _salaService.Editar(sala);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(Sala sala)
        {
            return await _salaService.Eliminar(sala);
        }
    }
}
