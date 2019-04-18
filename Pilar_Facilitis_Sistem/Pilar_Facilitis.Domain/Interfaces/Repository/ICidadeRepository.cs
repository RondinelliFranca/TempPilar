using System.Collections.Generic;
using System.Threading.Tasks;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Domain.Interfaces.Repository
{
    public interface ICidadeRepository
    {
        List<Cidade> BuscaTodosAsync(int id);
    }
}