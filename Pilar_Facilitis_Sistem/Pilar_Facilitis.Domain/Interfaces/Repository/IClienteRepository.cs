using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Domain.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> InsereAsync(Cliente cliente);
        Task<Cliente> Edita(Cliente cliente);
        Task<Cliente> BuscaAsync(Guid id);
        Task<List<Cliente>> BuscaTodosAsync();
        void Exclui(Cliente cliente);
        Task<List<Cliente>> BuscarPorNome(string nome);

    }
}