using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pilar_Facilitis.Domain.Entities
{    
    public class Cidade
    {
        [Key]
        public int Id { get; set; }

        public int IdEstado { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public virtual Estado Estado { get; set; }

        //public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}