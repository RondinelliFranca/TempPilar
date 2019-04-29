using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Domain.Interfaces.Repository;
using Pilar_Facilitis.Infra.Data.Contexts.Base;

namespace Pilar_Facilitis.Infra.Data.Repository
{
    public class ChamadosRepository : Repository<Chamado>, IChamadosRepository
    {
        protected IContexto _contexto { get; }
        protected DbSet<Chamado> Tabela { get; }

        public ChamadosRepository(IContexto contexto) : base(contexto)
        {
            _contexto = contexto;
            Tabela = contexto.Tabela<Chamado>();
        }

        public async Task<Chamado> Edita(Chamado chamado)
        {
            Tabela.Update(chamado).State = EntityState.Modified;
            var entity = Tabela.Update(chamado).Entity;
            return await Tabela.Include(e => e.Cliente)
                                        .Include(e => e.Servico)
                                        .Include(e => e.PontoAtendimento).FirstOrDefaultAsync();
        }

        public async Task<List<Chamado>> BuscaTodosAsync()
        {
            return Tabela.Include(e => e.Cliente)
                                 .Include(e => e.Servico)
                                 .Include(e => e.PontoAtendimento).ToList();
        }

        public async Task<List<Chamado>> BuscaTodosPorClienteAsync(Guid id)
        {
            return Tabela.Where(x => x.Cliente.Id == id)
                               .Include(e => e.Servico)
                               .Include(e => e.PontoAtendimento).ToList();
        }

        public Task<Chamado> BuscaPorId(Guid id)
        {
            return Tabela.Where(x => x.Id == id)
                .Include(e => e.Cliente)
                .Include(e => e.Servico)                                              
                .Include(e => e.PontoAtendimento)                                              
                .FirstOrDefaultAsync();
        }
    }
}