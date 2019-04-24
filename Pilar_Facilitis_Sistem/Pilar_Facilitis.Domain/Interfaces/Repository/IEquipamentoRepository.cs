using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Domain.Interfaces.Repository
{
    public interface IEquipamentoRepository
    {
        Task<Equipamento> InsereAsync(Equipamento equipamento);
        Task<Equipamento> Edita(Equipamento equipamento);
        Task<Equipamento> BuscaAsync(Guid id);
        Task<List<Equipamento>> BuscaTodosAsync();
        void Exclui(Equipamento equipamento);
        Task<List<Equipamento>> BuscarPorNome(string nome);
    }
}