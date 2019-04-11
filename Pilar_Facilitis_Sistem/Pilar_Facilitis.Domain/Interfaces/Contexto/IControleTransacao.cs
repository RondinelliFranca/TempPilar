namespace Pilar_Facilitis.Domain.Interfaces.Contexto
{
    public interface IControleTransacao
    {
        void Commit();
        void Rollback();
    }
}