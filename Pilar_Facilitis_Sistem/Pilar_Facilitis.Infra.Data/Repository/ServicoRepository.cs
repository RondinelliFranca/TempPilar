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
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        protected IContexto _contexto { get; }
        protected DbSet<Servico> Tabela { get; }
        public ServicoRepository(IContexto contexto) : base(contexto)
        {
            _contexto = contexto;
            Tabela = contexto.Tabela<Servico>();
        }        
        public async Task<Servico> Edita(Servico servico)
        {
            Tabela.Update(servico).State = EntityState.Modified;
            var entity = Tabela.Update(servico).Entity;
            return await Tabela.Where(x=>x.Id == servico.Id).FirstOrDefaultAsync();
        }

        public Task<Servico> BuscaAsync(Guid id)
        {
            return Tabela.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Servico>> BuscaTodosAsync()
        {
            return Tabela.ToList();
        }

        public void Exclui(Servico servico)
        {
            Tabela.Remove(servico);
        }

        public async Task<List<Servico>> BuscarPorNome(string nome)
        {
            return Tabela.Where(x => x.Desc_Servicos.Contains(nome)).ToList();
        }
    }
}