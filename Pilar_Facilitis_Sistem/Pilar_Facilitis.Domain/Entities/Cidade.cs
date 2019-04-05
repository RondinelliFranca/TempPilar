namespace Pilar_Facilitis.Domain.Entities
{
    public class Cidade
    {
        public int CidadeId { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public int PaisId { get; set; }

        public virtual Pais Pais { get; set; }

        public int EstadoId { get; set; }

        public virtual Estado Estado { get; set; }
    }
}