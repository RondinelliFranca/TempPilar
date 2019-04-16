using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilar_Facilitis.Domain.Entities
{
    public class Estado
    {        
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
