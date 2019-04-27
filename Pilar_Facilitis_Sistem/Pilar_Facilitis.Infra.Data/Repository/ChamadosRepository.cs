using System;
using System.Collections.Generic;
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

        public Task<Chamado> Edita(Chamado chamado)
        {
            throw new NotImplementedException();
        }

        public Task<List<Chamado>> BuscaTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Chamado>> BuscaTodosPorClienteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}