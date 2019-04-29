using System;
using System.Threading.Tasks;
using Pilar_Facilitis.Domain.Modelos;
using Pilar_Facilitis.Domain.ViewModel;

namespace Pilar_Facilitis.Domain.Interfaces.Service
{
    public interface IChamadosService
    {
        Task<Resposta> Adcionar(ChamadosViewModel chamadoViewModel);
        Task<Resposta> Atualizar(ChamadosViewModel clienteViewModel);
        Task<Resposta> ObterPorId(Guid id);
        Task<Resposta> ObterTodos();
        Task<Resposta> ObterTodosPorClienteId(Guid id);
    }
}