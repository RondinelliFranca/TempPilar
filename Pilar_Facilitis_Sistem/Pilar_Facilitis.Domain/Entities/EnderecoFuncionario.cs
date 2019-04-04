
using System;

namespace Pilar_Facilitis.Domain.Entities
{
    public class EnderecoFuncionario
    {
        public Guid EnderecoId { get; set; }
        public string RuaAv { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public int Pais { get; set; }
        public int Estado { get; set; }
        public int Cidade { get; set; }

        public Guid FuncId { get; set; }
        public FuncionarioPilar FuncionarioPilar { get; set; }

        public EnderecoFuncionario()
        {
            this.EnderecoId = Guid.NewGuid();
        }
    }
}
