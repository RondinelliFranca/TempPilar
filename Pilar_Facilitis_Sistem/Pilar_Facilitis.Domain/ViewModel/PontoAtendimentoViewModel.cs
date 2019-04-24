using System;
using Pilar_Facilitis.Api.ViewModel;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Domain.ViewModel
{
    public class PontoAtendimentoViewModel
    {
        public Guid? Id { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public string NomeResponsavel { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public virtual EnderecoViewModel Endereco { get; set; }
    }
}