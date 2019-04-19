using System;
using Pilar_Facilitis.Api.ViewModel;

namespace Pilar_Facilitis.Domain.ViewModel
{
    public class FuncionarioViewModel
    {
        public Guid? Id { get; set; }

        public string Nome { get; set; }

        public string RG { get; set; }

        public string CPF { get; set; }

        public string Telefone_Fixo { get; set; }

        public string Telefone_Cel { get; set; }

        public string Email { get; set; }

        public string Escolaridade { get; set; }

        public int Qtd_Dependentes { get; set; }

        public virtual EnderecoViewModel Endereco { get; set; }
    }
}