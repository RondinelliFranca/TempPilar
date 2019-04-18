using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pilar_Facilitis.Domain.Interfaces.Service;

namespace Pilar_Facilitis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _service;
        public EnderecoController(IEnderecoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("BuscarEstados")]
        public async Task<IActionResult> Buscar()
        {
            return Ok(await _service.ObterTodosEstados());
        }


        /// <summary>
        /// Teste de descrição susu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscarCidade/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            return Ok(await _service.ObterCidades(id));
        }
    }
}