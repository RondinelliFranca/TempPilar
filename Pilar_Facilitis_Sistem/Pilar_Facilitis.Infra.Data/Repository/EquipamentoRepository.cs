using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pilar_Facilitis.Domain.Entities;
using Pilar_Facilitis.Domain.Interfaces.Repository;
using Pilar_Facilitis.Infra.Data.Contexts.Base;

namespace Pilar_Facilitis.Infra.Data.Repository
{
    public class EquipamentoRepository : Repository<Equipamento>, IEquipamentoRepository
    {
        protected IContexto _contexto { get; }
        protected DbSet<Equipamento> Tabela { get; }
        public EquipamentoRepository(IContexto contexto) : base(contexto)
        {
            _contexto = contexto;
            Tabela = contexto.Tabela<Equipamento>();
        }

        public async Task<Equipamento> Edita(Equipamento equipamento)
        {
            Tabela.Update(equipamento).State = EntityState.Modified;
            var entity = Tabela.Update(equipamento).Entity;
            return await Tabela.Where(x => x.Id == equipamento.Id).FirstOrDefaultAsync();
        }

        public async Task<List<Equipamento>> BuscaTodosAsync()
        {
            return Tabela.ToList();
        }

        public Task<List<Equipamento>> BuscarPorNome(string nome)
        {
            throw new System.NotImplementedException();
        }
    }
}