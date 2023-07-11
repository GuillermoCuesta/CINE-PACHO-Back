using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;


        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Crear([FromBody] Usuario usuario)
        {
            return await _usuarioService.Crear(usuario);
        }

        [HttpPost]
        [Route("iniciar-sesion")]
        public async Task<IActionResult> IniciarSession([FromBody] Usuario credenciales)
        {
            return await _usuarioService.IniciarSession(credenciales);
        }

        [HttpGet]
        public async Task<IActionResult> Mostrar()
        {
            return await _usuarioService.Mostrar();
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] Usuario usuario)
        {
            return await _usuarioService.Editar(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return await _usuarioService.Eliminar(id);
        }
    }
}
