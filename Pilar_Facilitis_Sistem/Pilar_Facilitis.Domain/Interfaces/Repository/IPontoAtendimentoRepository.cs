using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Domain.Interfaces.Repository
{
    public interface IPontoAtendimentoRepository
    {
        Task<PontoAtendimentos> InsereAsync(PontoAtendimentos pontoAtendimento);
        Task<PontoAtendimentos> Edita(PontoAtendimentos pontoAtendimento);
        Task<PontoAtendimentos> BuscaAsync(Guid id);
        Task<List<PontoAtendimentos>> BuscaTodosAsync();
        Task<List<PontoAtendimentos>> BuscarPorClienteAsync(Guid id);
        void Exclui(PontoAtendimentos pontoAtendimento);
        Task<List<PontoAtendimentos>> BuscarPorNome(string nome);

    }
}