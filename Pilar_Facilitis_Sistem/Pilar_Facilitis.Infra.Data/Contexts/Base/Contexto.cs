using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Pilar_Facilitis.Infra.Data.Contexts.Base
{
    public abstract class Contexto : DbContext, IContexto
    {
        //public SqlConnection Connection { get; private set; }

        public string _conexaoString { get; private set; }

        public Contexto(DbContextOptions configuracao) : base(configuracao)
        {
            //_conexaoString = this.Database.GetDbConnection().ConnectionString;
        }

        public string ObterStringConexao()
        {
            return _conexaoString;
        }


        public DbSet<TEntidade> Tabela<TEntidade>() where TEntidade : class
        {
            return Set<TEntidade>();
        }

        public async Task<int> SalvaAlteracoesAsync()
        {
            try
            {
                return await SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //throw new SalvarException("O registro foi modificado por outro usuário.", ex);
            }
            //catch (DbEntityValidationException ex)
            //{
            //    throw new SalvarException("Ocorreu um erro ao validar os dados informados.", ex);
            //}
            catch (DbUpdateException ex)
            {
                //throw new SalvarException("Ocorreu um erro ao gravar as suas alterações.", ex);
            }

            return 1;//TODO Remover
        }

        public void GaranteEntidadeControlada<TEntidade>(TEntidade entidade, DbSet<TEntidade> dbSet) where TEntidade : class
        {
            if (Entry(entidade).State == EntityState.Detached)
                dbSet.Attach(entidade);
        }

        public void MarcaModificado<TEntidade>(TEntidade entidade, DbSet<TEntidade> dbSet) where TEntidade : class
        {
            GaranteEntidadeControlada(entidade, dbSet);

            //contexto.ChangeTracker.DetectChanges();
            Entry(entidade).State = EntityState.Modified;
        }

        public Task<IDbContextTransaction> IniciaTransacaoAsync()
        {
            return Database.BeginTransactionAsync();
        }
    }
}