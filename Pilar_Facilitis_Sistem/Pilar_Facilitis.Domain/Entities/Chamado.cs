using System;

namespace Pilar_Facilitis.Domain.Entities
{
    public class Chamado
    {
        public Chamado()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime DataSolicitacao { get; set; }        

        public int Prioridade { get; set; }        

        public int Status { get; set; }

        public string DescricaoProblema { get; set; }

        public string DescricaoAtendimento { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual PontoAtendimentos PontoAtendimento{ get; set; }
        public virtual Servico Servico{ get; set; }

    }
}