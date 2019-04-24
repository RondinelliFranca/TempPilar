using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilar_Facilitis.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            this.Id = Guid.NewGuid();
        }

        //[Key]
        public Guid? Id { get; set; }        

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string NomeResponsavel { get; set; }

        public string Email { get; set; }

        public virtual Endereco Endereco { get; set; }

        public virtual ICollection<PontoAtendimentos> PontosAtendimento { get; set; }
        public virtual ICollection<Chamado> Chamados { get; set; }


    }
}
