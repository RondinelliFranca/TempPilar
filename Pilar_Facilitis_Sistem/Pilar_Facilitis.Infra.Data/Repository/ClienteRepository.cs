using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Domain.Interfaces.Repository;
using Pilar_Facilitis.Infra.Data.Contexts.Base;

namespace Pilar_Facilitis.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        protected IContexto _contexto { get; }
        protected DbSet<Cliente> Tabela { get; }
        public ClienteRepository(IContexto contexto) : base(contexto)
        {
            _contexto = contexto;
            Tabela = contexto.Tabela<Cliente>();
        }

        public async Task<List<Cliente>> BuscaTodosAsync()
        {
            return Tabela.Include(e => e.Endereco).ToList();                       
        }

        public async Task<List<Cliente>> BuscarPorNome(string nome)
        {
            return Tabela.Where(x => x.NomeFantasia.Contains(nome)).Include(e => e.Endereco).ToList();
        }

        public async Task<Cliente> Edita(Cliente cliente)
        {
            Tabela.Update(cliente).State = EntityState.Modified;
            var entity = Tabela.Update(cliente).Entity;
            return await Tabela.Include(e => e.Endereco).FirstOrDefaultAsync();
        }

        public async Task<Cliente> BuscaAsync(Guid id)
        {
            return Tabela.Where(x => x.Id == id).Include(e => e.Endereco).FirstOrDefault();
        }

        public async void Exclui(Cliente cliente)
        {
            Tabela.Remove(cliente);
        }
    }
}