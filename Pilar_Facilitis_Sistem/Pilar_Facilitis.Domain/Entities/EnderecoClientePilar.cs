using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilar_Facilitis.Domain.Entities
{
    public class EnderecoClientePilar
    {
        public Guid EnderecoId { get; set; }
        public string RuaAv { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public int Pais { get; set; }
        public int Estado { get; set; }
        public int Cidade { get; set; }

        public Guid ClienteId { get; set; }
        public ClientePilar ClientePilar { get; set; }

        public EnderecoClientePilar()
        {
            this.EnderecoId = Guid.NewGuid();
        }
    }
}
