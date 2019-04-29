using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Domain.Interfaces.Repository
{
    public interface IChamadosRepository
    {
        Task<Chamado> InsereAsync(Chamado chamado);
        Task<Chamado> Edita(Chamado chamado);
        Task<Chamado> BuscaPorId(Guid id);
        Task<List<Chamado>> BuscaTodosAsync();
        Task<List<Chamado>> BuscaTodosPorClienteAsync(Guid id);
        
    }
}