using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Infra.Data.Contexts.EntityConfig
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Sigla);

            builder.HasMany(x => x.Cidades)
                .WithOne(s => s.Estado)
                .HasForeignKey(c => c.IdEstado);
        }
    }
}
