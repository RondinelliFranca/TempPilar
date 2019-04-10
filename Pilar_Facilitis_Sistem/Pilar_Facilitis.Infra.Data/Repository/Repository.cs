using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pilar_Facilitis.Infra.Data.Contexts.Base;

namespace Pilar_Facilitis.Infra.Data.Repository
{
    public class Repository<TEntidade> where TEntidade : class
    {
        protected IContexto Contexto { get; }

        protected DbSet<TEntidade> Tabela { get; }

        public Repository(IContexto contexto)
        {
            this.Contexto = contexto;
            Tabela = contexto.Tabela<TEntidade>();
        }

        public async virtual Task<IEnumerable<TEntidade>> BuscaTodosAsync()
        {
            return Tabela;
        }

        public async virtual Task<TEntidade> BuscaAsync(Guid id)
        {
            return (await Tabela.FindAsync(id));
        }

        public async virtual Task Edita(TEntidade entidade)
        {
            Contexto.MarcaModificado(entidade, Tabela);
        }

        public async Task<TEntidade> InsereAsync(TEntidade entidade)
        {
            return (await Tabela.AddAsync(entidade)).Entity;
        }


        public virtual Task InsereAsync(IEnumerable<TEntidade> entidade)
        {
            return Tabela.AddRangeAsync(entidade);
        }

        public async virtual Task<TEntidade> ExcluiAsync(object[] pk)
        {
            var entidade = await Tabela.FindAsync(pk);
            if (entidade == null)
                return null;
            Tabela.Remove(entidade);
            return entidade;
        }

        public virtual void Exclui(TEntidade entidade)
        {
            Contexto.GaranteEntidadeControlada(entidade, Tabela);

            Tabela.Remove(entidade);
        }
    }
}