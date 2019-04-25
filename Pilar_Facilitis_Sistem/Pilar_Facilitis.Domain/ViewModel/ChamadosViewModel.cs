using System;

namespace Pilar_Facilitis.Domain.ViewModel
{
    public class ChamadosViewModel
    {
        public Guid? Id { get; set; }        

        public int Prioridade { get; set; }

        public int? Status { get; set; }

        public string DescricaoProblema { get; set; }

        public string DescricaoAtendimento { get; set; }

        public Guid IdCliente { get; set; }

        public Guid IdPontoAtendimento { get; set; }

        public Guid IdServico { get; set; }
    }
}