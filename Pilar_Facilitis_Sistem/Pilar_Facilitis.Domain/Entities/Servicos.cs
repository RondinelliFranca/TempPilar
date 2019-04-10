using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilar_Facilitis.Domain.Entities
{
    public class Servicos
    {
        public Servicos()
        {
            this.ServicosId = Guid.NewGuid();
        }

        public Guid ServicosId { get; set; }

        public string Desc_Servicos { get; set; }

        public float Area { get; set; }
    }
}
