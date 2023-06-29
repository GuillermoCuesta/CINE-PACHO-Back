using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Services;


namespace WebApi.Controllers
{
    [Route("api/multiplex")]
    [ApiController]

    public class MultiplexController : ControllerBase, IMultiplexService
    {

        private readonly IMultiplexService _multiplexService;

        public MultiplexController(IMultiplexService multiplexService)
        {
            _multiplexService = multiplexService;
        }

        [HttpPost]
        [Route("api/multiplex/registrar")]
        public async Task<IActionResult> Crear([FromBody] Multiplex multiplex)
        {
            return await _multiplexService.Crear(multiplex);
        }

        [HttpGet]
        public async Task<IActionResult> Mostrar()
        {
            return await _multiplexService.Mostrar();
        }

        [HttpPut]
        [Route("api/multiplex/editar")]
        public async Task<IActionResult> Editar([FromBody] Multiplex multiplex)
        {
            return await _multiplexService.Editar(multiplex);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return await _multiplexService.Eliminar(id);
        }
    }
}
