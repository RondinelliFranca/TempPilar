using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Pilar_Facilitis.Infra.Data.Contexts.Base
{
    public interface IContexto
    {
        DbSet<TEntidade> Tabela<TEntidade>() where TEntidade : class;

        Task<int> SalvaAlteracoesAsync();

        void GaranteEntidadeControlada<TEntidade>(TEntidade entidade, DbSet<TEntidade> dbSet) where TEntidade : class;

        void MarcaModificado<TEntidade>(TEntidade entidade, DbSet<TEntidade> dbSet) where TEntidade : class;

        //Task<IEnumerable<T>> ExecutaConsultaAsync<T>(string query, IEnumerable<KeyValuePair<string, object>> parametros) where T : class;

        //Task<int> ExecutaComandoSqlAsync(string sql);

        Task<IDbContextTransaction> IniciaTransacaoAsync();

        //SqlConnection ObterConexao();

        string ObterStringConexao();
    }
}