using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApi.Data_Access;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase, IUsuarioService
    {

        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("api/usuarios/registrar")]
        public async Task<IActionResult> Crear([FromBody] Usuario usuario)
        {
            return await _usuarioService.Crear(usuario);
        }

        [HttpPost]
        [Route("api/usuarios/iniciar-sesion")]
        public async Task<IActionResult> IniciarSession([FromBody] Usuario credenciales)
        {
            return await _usuarioService.IniciarSession(credenciales);
        }

        [HttpGet]
        public async Task<IActionResult> Mostrar()
        {
            return await _usuarioService.Mostrar();
        }

        [HttpPut("{id}")]
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
