using System;
using System.Collections;
using System.Collections.Generic;

namespace Pilar_Facilitis.Domain.Entities
{
    public class Endereco
    {
        public Endereco()
        {
            EnderecoId = Guid.NewGuid();
        }

        public Guid EnderecoId { get; set; }

        public string RuaAv { get; set; }

        public int Numero { get; set; }

        public string Bairro { get; set; }

        public int Pais { get; set; }

        public int Estado { get; set; }

        public int Cidade { get; set; }

        #region Relacionamentos
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
        public ICollection<PontoAtendimentos> PontosAtendimentos { get; set; }

        #endregion

    }
}