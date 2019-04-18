using System.Threading.Tasks;
using Pilar_Facilitis.Domain.Modelos;

namespace Pilar_Facilitis.Domain.Interfaces.Service
{
    public interface IEnderecoService
    {
        Task<Resposta> ObterTodosEstados();
        Task<Resposta> ObterCidades(int id);
    }
}