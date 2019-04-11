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

        [HttpPost]
        public async Task<Cliente> Criar([FromBody] ClienteViewModel cliente)
        {
            return await _service.Adcionar(cliente);
        }
    }
}