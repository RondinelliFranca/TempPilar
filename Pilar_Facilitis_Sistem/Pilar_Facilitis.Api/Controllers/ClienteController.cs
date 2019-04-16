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
    public class ClienteController : Controller
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
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
            return Ok(await _service.ObterPorID(id));
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ClienteViewModel cliente)
        {
            return Ok(await _service.Adcionar(cliente));
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] ClienteViewModel cliente)
        {
            return Ok(await _service.Atualizar(cliente));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            return Ok(await _service.Remover(id));
        }
    }
}