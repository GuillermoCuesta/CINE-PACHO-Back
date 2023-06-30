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
    public class UsuarioController : ControllerBase
    {

        private readonly IEntityService<Usuario> _entityService;
        private readonly IUsuarioService _usuarioService;


        public UsuarioController(IEntityService<Usuario> entityService, IUsuarioService usuarioService)
        {
            _entityService = entityService;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Crear([FromBody] Usuario usuario)
        {
            return await _entityService.Crear(usuario);
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
            return await _entityService.Mostrar();
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] Usuario usuario)
        {
            return await _entityService.Editar(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return await _entityService.Eliminar(id);
        }
    }
}
