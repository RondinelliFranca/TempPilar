using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilar_Facilitis.Domain.Entities
{
    public class Equipamentos
    {
        public Guid EquipamentoId { get; set; }
        public string Desc_Equip { get; set; }
        public decimal Capacidade { get; set; }
        public string Fabricante { get; set; }
        public string NumDeSerie { get; set; }

        public Equipamentos()
        {
            this.EquipamentoId = Guid.NewGuid();
        }
    }
}
