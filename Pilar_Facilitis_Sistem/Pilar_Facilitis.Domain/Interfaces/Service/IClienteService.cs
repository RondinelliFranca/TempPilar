using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Domain.ViewModel;

namespace Pilar_Facilitis.Domain.Interfaces.Service
{
    public interface IClienteService
    {
        Task<Cliente> Adcionar(ClienteViewModel cliente);
        Task<Cliente> Atualizar(Cliente cliente);
        Task<Cliente> ObterPorID(Guid id);        
        Task<IEnumerable<Cliente>> ObterTodos();
        void Remover(Guid id);
    }
}