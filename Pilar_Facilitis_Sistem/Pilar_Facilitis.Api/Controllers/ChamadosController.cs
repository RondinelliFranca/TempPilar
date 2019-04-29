using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pilar_Facilitis.Api.ViewModel;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Domain.Interfaces.Service;
using Pilar_Facilitis.Domain.ViewModel;

namespace Pilar_Facilitis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChamadosController : Controller
    {
        private readonly IChamadosService _service;

        public ChamadosController(IChamadosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Buscar()
        {
            return Ok(await _service.ObterTodos());
        }

        [HttpGet("porid/{id}")]
        public async Task<IActionResult> Buscar(Guid id)
        {
            return Ok(await _service.ObterPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ChamadosViewModel chamados)
        {
            return Ok(await _service.Adcionar(chamados));
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] ChamadosViewModel chamados)
        {
            return Ok(await _service.Atualizar(chamados));
        }

        [HttpGet("todosporid/{id}")]
        public async Task<IActionResult> BuscarTodosPorCliente(Guid id)
        {
            return Ok(await _service.ObterTodosPorClienteId(id));
        }

    }
}