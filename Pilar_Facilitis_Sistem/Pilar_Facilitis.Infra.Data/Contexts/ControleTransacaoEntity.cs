using Microsoft.EntityFrameworkCore.Storage;
using Pilar_Facilitis.Domain.Interfaces.Contexto;

namespace Pilar_Facilitis.Infra.Data.Contexts
{
    public class ControleTransacaoEntity : IControleTransacao
    {
        private readonly IDbContextTransaction transacao;

        public ControleTransacaoEntity(IDbContextTransaction transacao)
        {
            this.transacao = transacao;
        }

        public void Commit()
        {
            transacao.Commit();
        }

        public void Rollback()
        {
            transacao.Rollback();
        }

        public void Dispose()
        {
            transacao.Dispose();
        }
    }
}