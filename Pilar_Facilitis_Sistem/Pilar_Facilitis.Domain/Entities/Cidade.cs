using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pilar_Facilitis.Domain.Entities
{    
    public class Cidade
    {        
        public int Id { get; set; }

        public int EstadoId { get; set; }

        public string Nome { get; set; }        

        public virtual Estado Estado { get; set; }
        
    }
}