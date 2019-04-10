using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Domain.Interfaces.Service
{
    public interface IClienteService : IDisposable
    {
        Cliente Adcionar(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        Cliente ObterPorID(Guid id);
        IEnumerable<Cliente> Buscar(Expression<Func<Cliente, bool>> predicate);
        IEnumerable<Cliente> ObterTodos();
        void Remover(Guid id);
    }
}