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

    public class MultiplexController : ControllerBase
    {

        private readonly IEntityService<Multiplex> _entityService;
        private readonly IDeleteIntService _deleteService;
        private readonly IReadService _readService;


        public MultiplexController(IEntityService<Multiplex> entityService, MultiplexService deleteService, IReadService readService)
        {
            _entityService = entityService;
            _deleteService = deleteService;
            _readService = readService;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Crear([FromBody] Multiplex multiplex)
        {
            return await _entityService.Crear(multiplex);
        }

        [HttpGet]
        public async Task<IActionResult> Mostrar()
        {
            return await _readService.Mostrar();
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Editar([FromBody] Multiplex multiplex)
        {
            return await _entityService.Editar(multiplex);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return await _deleteService.Eliminar(id);
        }
    }
}
