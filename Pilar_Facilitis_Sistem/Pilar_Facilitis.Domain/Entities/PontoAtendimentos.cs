using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilar_Facilitis.Domain.Entities
{
    public class PontoAtendimentos
    {
        public PontoAtendimentos()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid? Id { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public string NomeResponsavel { get; set; }

        public string Email { get; set; }
        public Cliente Cliente { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
