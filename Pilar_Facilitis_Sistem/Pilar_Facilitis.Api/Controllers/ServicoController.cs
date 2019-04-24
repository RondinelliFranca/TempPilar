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
    public class ServicoController : Controller
    {
        private readonly IServicoService _service;

        public ServicoController(IServicoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Buscar()
        {            
            return Ok(await _service.ObterTodos());
        }

        [HttpGet("porNome/{nome}")]
        public async Task<IActionResult> Buscar(string nome)
        {
            return Ok(await _service.ObterPorNome(nome));
        }

        [HttpGet("porid/{id}")]
        public async Task<IActionResult> Buscar(Guid id)
        {
            return Ok(await _service.ObterPorID(id));
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ServicoViewModel servico)
        {
            return Ok(await _service.Adcionar(servico));
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] ServicoViewModel servico)
        {
            return Ok(await _service.Atualizar(servico));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            return Ok(await _service.Remover(id));
        }
    }
}