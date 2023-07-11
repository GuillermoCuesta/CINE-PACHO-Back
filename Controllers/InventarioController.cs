using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/inventarios")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        public readonly IInventarioService _inventarioService;
        public InventarioController(IInventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Crear([FromBody] Inventario inventario)
        {
            return await _inventarioService.Crear(inventario);
        }

        [HttpGet]
        [Route("mostrar")]
        public async Task<IActionResult> Mostrar(int multiplex)
        {
            return await _inventarioService.Mostrar(multiplex);
        }

        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] Inventario inventario)
        {
            return await _inventarioService.Actualizar(inventario);
        }
    }
}
