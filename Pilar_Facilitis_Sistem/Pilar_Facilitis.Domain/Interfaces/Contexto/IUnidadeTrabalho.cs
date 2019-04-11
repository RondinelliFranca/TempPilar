using System.Threading.Tasks;

namespace Pilar_Facilitis.Domain.Interfaces.Contexto
{
    public interface IUnidadeTrabalho
    {
        Task<int> SalvaAlteracoesAsync();
        Task<IControleTransacao> IniciaTransacaoAsync();
    }
}