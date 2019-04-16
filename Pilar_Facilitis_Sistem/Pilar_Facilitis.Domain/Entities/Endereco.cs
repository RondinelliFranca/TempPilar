using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pilar_Facilitis.Domain.Entities
{
    public class Endereco
    {
        public Endereco()
        {
            Id = Guid.NewGuid();
        }

        public Guid? Id { get; set; }

        public Guid? IdCliente { get; set; }

        public Guid? IdFuncionario { get; set; }

        public Guid? IdPontoAtendimento { get; set; }

        public string RuaAv { get; set; }

        public int Numero { get; set; }

        public string Bairro { get; set; }

        public string Complemento { get; set; }

        public int Pais { get; set; }

        public int Estado { get; set; }

        public int IdCidade { get; set; }

    }
}