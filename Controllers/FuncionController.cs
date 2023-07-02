using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/funciones")]
    [ApiController]
    public class FuncionController : ControllerBase
    {
        private readonly IEntityService<Funcion> _entityService;
        private readonly IDeleteIntService _deleteService;
        private readonly IReadIntService _readIntService;



        public FuncionController(IEntityService<Funcion> entityService, FuncionService deleteService, FuncionService readIntService)
        {
            _entityService = entityService;
            _deleteService = deleteService;
            _readIntService = readIntService;
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Crear([FromBody] Funcion funcion)
        {
            return await _entityService.Crear(funcion);
        }

        [HttpGet]
        public async Task<IActionResult> Mostrar(int multiplex)
        {
            return await _readIntService.Mostrar(multiplex);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Editar([FromBody] Funcion funcion)
        {
            return await _entityService.Editar(funcion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return await _deleteService.Eliminar(id);
        }
    }
}
