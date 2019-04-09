using System;

namespace Pilar_Facilitis.Domain.Entities
{
    public class Funcionario
    {
        public Funcionario()
        {
            this.FuncId = Guid.NewGuid();
        }

        public Guid FuncId { get; set; }        

        public string Nome { get; set; }

        public string RG { get; set; }

        public string CPF { get; set; }

        public string Telefone_Fixo { get; set; }

        public string Telefone_Cel { get; set; }

        public string Email { get; set; }

        public string Escolaridade { get; set; }

        public int Qtd_Dependentes { get; set; }

        //public virtual Endereco Endereco { get; set; }

        //public Guid EnderecoId { get; set; }
    }
}
