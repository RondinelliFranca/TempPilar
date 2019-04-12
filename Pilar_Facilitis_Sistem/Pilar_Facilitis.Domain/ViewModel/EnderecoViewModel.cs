using System;

namespace Pilar_Facilitis.Api.ViewModel
{
    public class EnderecoViewModel
    {
        public Guid? EnderecoId { get; set; }

        public string RuaAv { get; set; }

        public int Numero { get; set; }

        public string Bairro { get; set; }

        public int Pais { get; set; }

        public int Estado { get; set; }

        public int Cidade { get; set; }
    }
}