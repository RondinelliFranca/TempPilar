using System;
using System.Threading.Tasks;
using Pilar_Facilitis.Domain.Modelos;
using Pilar_Facilitis.Domain.ViewModel;

namespace Pilar_Facilitis.Domain.Interfaces.Service
{
    public interface IEquipamentoService
    {
        Task<Resposta> Adcionar(EquipamentoViewModel equipamentoViewModel);
        Task<Resposta> Atualizar(EquipamentoViewModel equipamento);
        Task<Resposta> ObterPorID(Guid id);
        Task<Resposta> ObterTodos();
        Task<Resposta> ObterPorNome(string nome);
        Task<Resposta> Remover(Guid id);
    }
}