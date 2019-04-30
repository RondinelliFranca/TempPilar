using System;

namespace Pilar_Facilitis.Domain.ViewModel
{
    public class ChamadosRetornoViewModel
    {
        public Guid Id { get; set; }

        public DateTime DataSolicitacao { get; set; } 

        public int Prioridade { get; set; }

        public int Status { get; set; } = 1;

        public string DescricaoProblema { get; set; }

        public string DescricaoAtendimento { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
        public virtual PontoAtendimentoViewModel PontoAtendimento { get; set; }
        public virtual ServicoViewModel Servico { get; set; }
    }
}