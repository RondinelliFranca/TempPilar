using System;
using Pilar_Facilitis.Api.ViewModel;

namespace Pilar_Facilitis.Domain.ViewModel
{
    public class ClienteViewModel
    {
        public Guid? ClienteId { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string NomeResponsavel { get; set; }

        public string Email { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}