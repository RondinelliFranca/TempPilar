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
    public class PontoAtendimentoRepository : Repository<PontoAtendimentos>, IPontoAtendimentoRepository
    {
        protected IContexto _contexto { get; }
        protected DbSet<PontoAtendimentos> Tabela { get; }
        public PontoAtendimentoRepository(IContexto contexto) : base(contexto)
        {
            _contexto = contexto;
            Tabela = contexto.Tabela<PontoAtendimentos>();
        }

        public async Task<PontoAtendimentos> Edita(PontoAtendimentos pontoAtendimento)
        {
            Tabela.Update(pontoAtendimento).State = EntityState.Modified;
            var entity = Tabela.Update(pontoAtendimento).Entity;
            return await Tabela.Include(e => e.Endereco).FirstOrDefaultAsync();
        }

        public async Task<List<PontoAtendimentos>> BuscaTodosAsync()
        {
            return Tabela.Include(e => e.Endereco).ToList();
        }

        public async Task<List<PontoAtendimentos>> BuscarPorClienteAsync(Guid id)
        {
            return Tabela.Where(x=>x.Cliente.Id == id).Include(e => e.Endereco).ToList();
        }

        public async Task<List<PontoAtendimentos>> BuscarPorNome(string nome)
        {
            return Tabela.Where(x => x.Nome.Contains(nome)).Include(e => e.Endereco).ToList();
        }

        public void Exclui(PontoAtendimentos pontoAtendimentos)
        {
            Tabela.Remove(pontoAtendimentos);
        }

        public async Task<PontoAtendimentos> BuscaAsync(Guid id)
        {
            return Tabela.Where(x => x.Id == id).Include(e => e.Endereco).Include(c => c.Cliente).FirstOrDefault();
        }
    }
}