using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilar_Facilitis.Domain.Entities
{
    public class Equipamentos
    {
        public Equipamentos()
        {
            this.EquipamentoId = Guid.NewGuid();
        }

        public Guid EquipamentoId { get; set; }

        public string Desc_Equip { get; set; }

        public float Capacidade { get; set; }

        public string Fabricante { get; set; }

        public string NumDeSerie { get; set; }        
    }
}
