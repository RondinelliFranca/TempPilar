using System;
using System.Threading.Tasks;
using Pilar_Facilitis.Domain.Modelos;
using Pilar_Facilitis.Domain.ViewModel;

namespace Pilar_Facilitis.Domain.Interfaces.Service
{
    public interface IPontoAtendimentoService
    {
        Task<Resposta> Adcionar(PontoAtendimentoViewModel pontoAtendimento);
        Task<Resposta> Atualizar(PontoAtendimentoViewModel pontoAtendimentoViewModel);
        Task<Resposta> ObterPorID(Guid id);
        Task<Resposta> ObterPorCliente(Guid id);
        Task<Resposta> ObterTodos();
        Task<Resposta> ObterPorNome(string nome);
        Task<Resposta> Remover(Guid id);
    }
}