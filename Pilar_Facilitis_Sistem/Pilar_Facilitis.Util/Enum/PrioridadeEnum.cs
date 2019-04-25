using System.Security.Cryptography;

namespace Pilar_Facilitis.Util.Enum
{
    public class PrioridadeEnum
    {
        public static PrioridadeEnum BAIXO = new PrioridadeEnum(1, "Baixo");
        public static PrioridadeEnum MEDIO = new PrioridadeEnum(2, "Medio");
        public static PrioridadeEnum ALTA = new PrioridadeEnum(3, "Alta");

        public int Valor { get; set; }
        public string Descricao { get; set; }

        public PrioridadeEnum(int valor, string descricao)
        {
            Valor = valor;
            Descricao = descricao;
        }
    }
}