using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/compras")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _compraService;

        public CompraController(CompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Crear([FromBody] CompraCliente compracliente)
        {
            return await _compraService.Crear(compracliente);
        }

        [HttpGet]
        [Route("mostrar")]
        public async Task<IActionResult> Mostrar()
        {
            return await _compraService.Mostrar();
        }

    }
}
