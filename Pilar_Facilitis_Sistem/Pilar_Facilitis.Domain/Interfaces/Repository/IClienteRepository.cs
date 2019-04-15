using System;
using System.Threading.Tasks;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Domain.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> InsereAsync(Cliente cliente);
        Task Edita(Cliente cliente);
        Task<Cliente> BuscaAsync(Guid id);
    }
}