using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/snacks")]
    [ApiController]
    public class SnackController : ControllerBase, ISnackService
    {
        private readonly ISnackService _snackService;
        public SnackController(ISnackService snackService)
        {
            _snackService = snackService;
        }

        [HttpGet]
        [Route("agregar")]
        public async Task<IActionResult> Crear(Snack snack)
        {
            return await _snackService.Crear(snack);
        }

        [HttpPost]
        [Route("mostrar")]
        public async Task<IActionResult> Mostrar(int multiplex)
        {
            return await _snackService.Mostrar(multiplex);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Editar(Snack snack)
        {
            return await _snackService.Editar(snack);
        }
    }
}
