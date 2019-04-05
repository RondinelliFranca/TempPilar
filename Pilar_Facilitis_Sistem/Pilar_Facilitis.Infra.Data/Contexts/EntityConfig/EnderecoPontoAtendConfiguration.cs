using Pilar_Facilitis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilar_Facilitis.Infra.Data.EntityConfig
{
    public class EnderecoPontoAtendConfiguration : EntityTypeConfiguration<EnderecoPontoAtendimento>
    {
        public EnderecoPontoAtendConfiguration()
        {
            HasKey(c => c.EnderecoId);

            Property(e => e.RuaAv)
                .IsRequired()
                .HasMaxLength(200);

            Property(e => e.Numero)
                .IsRequired();

            Property(e => e.Pais)
                .IsRequired();

            Property(e => e.Estado)
                .IsRequired();

            Property(e => e.Cidade)
                .IsRequired();

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(200);

            HasRequired(e => e.PontoAtendimentos)
                .WithMany()
                .HasForeignKey(e => e.PontoAtendId);
        }
    }
}
