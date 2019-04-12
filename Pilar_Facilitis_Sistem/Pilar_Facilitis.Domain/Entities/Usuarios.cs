using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilar_Facilitis.Domain.Entities
{
    public class Usuarios
    {
        [Key]
        public string Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Tipo { get; set; }
    }
}
