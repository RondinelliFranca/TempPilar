using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilar_Facilitis.Domain.Entities
{
    public class ClientePilar
    {
        public Guid ClienteId { get; set; }
        public EnderecoClientePilar endereco { get; set; }

        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneCel { get; set; }
        public string NomeResponsavel { get; set; }
        public string Email { get; set; }

        public ClientePilar()
        {
            this.ClienteId = Guid.NewGuid();
            endereco = new EnderecoClientePilar();
        }
    }
}
