using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApi.Data_Access;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {

        private readonly IEntityService<Usuario> _entityService;
        private readonly IUsuarioService _usuarioService;
        private readonly IDeleteIntService _deleteService;


        public UsuarioController(IEntityService<Usuario> entityService, UsuarioService deleteService, IUsuarioService usuarioService)
        {
            _entityService = entityService;
            _deleteService = deleteService;
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
            return await _usuarioService.Mostrar();
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] Usuario usuario)
        {
            return await _entityService.Editar(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return await _deleteService.Eliminar(id);
        }
    }
}
