using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Domain.Interfaces.Repository
{
    public interface IServicoRepository
    {
        Task<Servico> InsereAsync(Servico servico);
        Task<Servico> Edita(Servico servico);
        Task<Servico> BuscaAsync(Guid id);
        Task<List<Servico>> BuscaTodosAsync();
        void Exclui(Servico servico);
        Task<List<Servico>> BuscarPorNome(string nome);
    }
}