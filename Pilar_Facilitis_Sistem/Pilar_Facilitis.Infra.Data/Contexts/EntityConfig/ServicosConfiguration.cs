using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pilar_Facilitis.Domain.Entities;

namespace Pilar_Facilitis.Infra.Data.Contexts.EntityConfig
{
    public class ServicosConfiguration : IEntityTypeConfiguration<Servicos>
    {
        public void Configure(EntityTypeBuilder<Servicos> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Desc_Servicos)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Area)
                .IsRequired();
        }
    }
}
