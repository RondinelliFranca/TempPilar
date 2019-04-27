using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pilar_Facilitis.Domain.Interfaces.Service;
using Pilar_Facilitis.Domain.ViewModel;

namespace Pilar_Facilitis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontoAtendimentoController : ControllerBase
    {
        private readonly IPontoAtendimentoService _service;

        public PontoAtendimentoController(IPontoAtendimentoService service)
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
        public async Task<IActionResult> Criar([FromBody] PontoAtendimentoViewModel pontoAtendimento)
        {
            return Ok(await _service.Adcionar(pontoAtendimento));
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] PontoAtendimentoViewModel pontoAtendimento)
        {
            return Ok(await _service.Atualizar(pontoAtendimento));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            return Ok(await _service.Remover(id));
        }

        [HttpGet("porCliente/{id}")]
        public async Task<IActionResult> BuscarPorCliente(Guid id)
        {
            return Ok(await _service.ObterPorCliente(id));
        }
    }
}
