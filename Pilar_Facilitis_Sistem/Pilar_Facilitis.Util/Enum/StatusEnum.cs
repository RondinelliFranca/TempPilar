namespace Pilar_Facilitis.Util.Enum
{
    public class StatusEnum
    {
        public static StatusEnum ABERTO = new StatusEnum(1, "Aberto");
        public static StatusEnum EM_ANDAMENTO = new StatusEnum(2, "Em andamento");
        public static StatusEnum CONCLUIDO = new StatusEnum(3, "Concluido");

        public int Valor { get; set; }
        public string Descricao { get; set; }

        public StatusEnum(int valor, string descricao)
        {
            Valor = valor;
            Descricao = descricao;
        }
    }
}