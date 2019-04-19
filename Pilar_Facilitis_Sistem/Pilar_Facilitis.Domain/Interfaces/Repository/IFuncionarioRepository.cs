using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Domain.Interfaces.Repository
{
    public interface IFuncionarioRepository
    {
        Task<Funcionario> InsereAsync(Funcionario funcionario);
        Task<Funcionario> Edita(Funcionario funcionario);
        Task<Funcionario> BuscaAsync(Guid id);
        Task<List<Funcionario>> BuscaTodosAsync();
        void Exclui(Funcionario funcionario);
        Task<List<Funcionario>> BuscarPorNome(string nome);
    }
}