using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Domain.Modelos;
using Pilar_Facilitis.Domain.ViewModel;

namespace Pilar_Facilitis.Domain.Interfaces.Service
{
    public interface IServicoService
    {
        Task<Resposta> Adcionar(ServicoViewModel servicoViewModel);
        Task<Resposta> Atualizar(ServicoViewModel servico);
        Task<Resposta> ObterPorID(Guid id);        
        Task<Resposta> ObterTodos();
        Task<Resposta> ObterPorNome(string nome);
        Task<Resposta> Remover(Guid id);
    }
}