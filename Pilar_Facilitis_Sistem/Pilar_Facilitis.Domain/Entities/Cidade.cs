namespace Pilar_Facilitis.Domain.Entities
{
    public class Cidade
    {
        public int CidadeId { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public int PaisId { get; set; }
        public Pais Pais { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
    }
}