using System.Threading.Tasks;
using Pilar_Facilitis.Domain.Interfaces.Contexto;
using Pilar_Facilitis.Infra.Data.Contexts.Base;

namespace Pilar_Facilitis.Infra.Data.Contexts
{
    public class UnidadeTrabalhoEntity : IUnidadeTrabalho
    {
        private readonly IContexto contexto;

        public UnidadeTrabalhoEntity(IContexto contexto)
        {
            this.contexto = contexto;
        }

        public Task<int> SalvaAlteracoesAsync()
        {
            return contexto.SalvaAlteracoesAsync();
        }

        public async Task<IControleTransacao> IniciaTransacaoAsync()
        {
            return new ControleTransacaoEntity(await contexto.IniciaTransacaoAsync());
        }
    }
}