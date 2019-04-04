using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilar_Facilitis.Domain.Entities
{
    public class EnderecoPontoAtendimento
    {
        public Guid EnderecoId { get; set; }
        public string RuaAv { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public int Pais { get; set; }
        public int Estado { get; set; }
        public int Cidade { get; set; }

        public Guid PontoAtendId { get; set; }
        public PontoAtendimentos PontoAtendimentos { get; set; }

        public EnderecoPontoAtendimento()
        {
            this.EnderecoId = Guid.NewGuid();
        }
    }
}
