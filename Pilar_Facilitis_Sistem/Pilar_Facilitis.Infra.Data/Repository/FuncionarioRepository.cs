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
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        protected IContexto _contexto { get; }
        protected DbSet<Funcionario> Tabela { get; }
        public FuncionarioRepository(IContexto contexto) : base(contexto)
        {
            _contexto = contexto;
            Tabela = contexto.Tabela<Funcionario>();
        }
       
        public async Task<Funcionario> Edita(Funcionario funcionario)
        {
            Tabela.Update(funcionario).State = EntityState.Modified;
            var entity = Tabela.Update(funcionario).Entity;
            return await Tabela.Include(e => e.Endereco).FirstOrDefaultAsync();
        }

        public async Task<Funcionario> BuscaAsync(Guid id)
        {
            return Tabela.Where(x => x.Id == id).Include(e => e.Endereco).FirstOrDefault();
        }

        public async Task<List<Funcionario>> BuscaTodosAsync()
        {
            return Tabela.Include(e => e.Endereco).ToList();
        }

        public void Exclui(Funcionario funcionario)
        {
            Tabela.Remove(funcionario);
        }

        public async Task<List<Funcionario>> BuscarPorNome(string nome)
        {
            return Tabela.Where(x => x.Nome.Contains(nome)).Include(e => e.Endereco).ToList();
        }
    }
}