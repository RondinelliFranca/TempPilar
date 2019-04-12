using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Infra.Data.Contexts.EntityConfig
{
    public class PontoAtendConfiguration : IEntityTypeConfiguration<PontoAtendimentos>
    {
        public void Configure(EntityTypeBuilder<PontoAtendimentos> builder)
        {
            builder.HasKey(c => c.Id);

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

            builder.HasOne(x => x.Endereco)
                .WithOne()
                .HasForeignKey<Endereco>(e => e.IdFuncionario);

            //builder.HasOne(c => c.Cliente)
            //    .WithMany(e => e.PontosAtendimento);
        }
    }
}
