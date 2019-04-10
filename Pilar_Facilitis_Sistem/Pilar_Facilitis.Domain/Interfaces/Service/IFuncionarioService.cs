using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Domain.Interfaces.Service
{
    public interface IFuncionarioService : IDisposable
    {
        Funcionario Adcionar(Funcionario funcionario);
        Funcionario Atualizar(Funcionario funcionario);
        Funcionario ObterPorId(Guid id);
        IEnumerable<Funcionario> Buscar(Expression<Func<Funcionario, bool>> predicate);
        IEnumerable<Funcionario> ObterTodos();
        void Remover(Guid id);
    }
}