using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilar_Facilitis.Domain.Entities
{
    public class PontoAtendimentos
    {
        public PontoAtendimentos()
        {
            this.PontoAtendId = Guid.NewGuid();
        }

        public Guid PontoAtendId { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public string NomeResponsavel { get; set; }

        public string Email { get; set; }

        public Guid ClienteId { get; set; }
            
    }
}
