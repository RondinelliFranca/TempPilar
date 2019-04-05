using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Infra.Data.Contexts.EntityConfig
{
    public class PontoAtendConfiguration : IEntityTypeConfiguration<PontoAtendimentos>
    {
        public void Configure(EntityTypeBuilder<PontoAtendimentos> builder)
        {
            builder.HasKey(c => c.PontoAtendId);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.NomeResponsavel)
                .IsRequired();

            builder.Property(p => p.Sigla)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(60);

            //HasRequired(p => p.Cliente)
            //    .WithMany()
            //    .HasForeignKey(p => p.ClienteId);
        }
    }
}
