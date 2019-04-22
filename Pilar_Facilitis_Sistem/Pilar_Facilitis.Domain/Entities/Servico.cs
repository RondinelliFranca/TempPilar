using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilar_Facilitis.Domain.Entities
{
    public class Servico
    {
        public Servico()
        {
            this.Id = Guid.NewGuid();
        }

        //[Key]
        public Guid Id { get; set; }

        public string Desc_Servicos { get; set; }

        public float Area { get; set; }
    }
}
