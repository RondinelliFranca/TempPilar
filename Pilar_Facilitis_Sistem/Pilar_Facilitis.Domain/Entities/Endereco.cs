using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pilar_Facilitis.Domain.Entities
{
    public class Endereco
    {
        public Endereco()
        {
            EnderecoId = Guid.NewGuid();
        }

        public Guid? EnderecoId { get; set; }

        public string RuaAv { get; set; }

        public int Numero { get; set; }

        public string Bairro { get; set; }

        public int Pais { get; set; }

        public int Estado { get; set; }

        public int Cidade { get; set; }

        //[ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        public Guid? ClienteId { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public Guid? FuncionarioId { get; set; }
        public virtual PontoAtendimentos PontoAtendimento { get; set; }
        public Guid? PontoAtendimentoId { get; set; }
        

    }
}