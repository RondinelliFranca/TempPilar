using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Domain.Interfaces.Repository;
using Pilar_Facilitis.Infra.Data.Contexts.Base;

namespace Pilar_Facilitis.Infra.Data.Repository
{
    public class CidadeRepository: Repository<Cidade>, ICidadeRepository
    {
        protected IContexto _contexto { get; }
        protected DbSet<Cidade> Tabela { get; }
        public CidadeRepository(IContexto contexto) : base(contexto)
        {
            _contexto = contexto;
            Tabela = contexto.Tabela<Cidade>();
        }

        public List<Cidade> BuscaTodosAsync(int id)
        {
            return Tabela.Where(x => x.EstadoId == id).ToList();
        }
    }
}