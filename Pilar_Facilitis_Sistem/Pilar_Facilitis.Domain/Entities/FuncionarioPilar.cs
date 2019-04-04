using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pilar_Facilitis.Domain.Entities
{
    public class FuncionarioPilar
    {
        public Guid FuncId { get; set; }

        public EnderecoFuncionario endereco { get; set; }

        public string Nome { get; set; }

        public string RG { get; set; }

        public string CPF { get; set; }

        public string Telefone_Fixo { get; set; }

        public string Telefone_Cel { get; set; }

        public string Email { get; set; }

        public string Escolaridade { get; set; }

        public int Qtd_Dependentes { get; set; }

        public FuncionarioPilar()
        {
            this.FuncId = Guid.NewGuid();
            endereco = new EnderecoFuncionario();
        }

    }
}
